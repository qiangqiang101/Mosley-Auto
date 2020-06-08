Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports System.Drawing
Imports INMNativeUI
Imports Metadata

Public Class MosleyAuto
    Inherits Script

    Public Sub New()
        If Not Native.Function.Call(Of Boolean)(Hash.HAS_THIS_ADDITIONAL_TEXT_LOADED, "mod_mnu", 19) Then
            Native.Function.Call(Hash.CLEAR_ADDITIONAL_TEXT, 19, True)
            Native.Function.Call(Hash.REQUEST_ADDITIONAL_TEXT, "mod_mnu", 19)
        End If

        LoadSettings()

        _menuPool = New MenuPool()
        camera = New WorkshopCamera
        BtnFirstPerson = New InstructionalButton(fpcKey, Game.GetGXTEntry("MO_ZOOM_FIRST")) 'MO_ZOOM_FIRST   LOB_FCP_1
        BtnZoom = New InstructionalButton(zinKey, Game.GetGXTEntry("INPUT_CREATOR_ZOOM_IN_DISPLAYONLY")) 'CELL_284
        BtnZoomOut = New InstructionalButton(zoutKey, Game.GetGXTEntry("INPUT_CREATOR_ZOOM_OUT_DISPLAYONLY"))
        CreateMenus()
        Native.Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "VEHICLE_SHOP_HUD_1", False, -1)
        Native.Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "VEHICLE_SHOP_HUD_2", False, -1)

        mosleyIntID = GetInteriorID(New Vector3(-11.66313, -1667.733, 28.90435))
        CreateBlip()
        Game.Globals(GetGlobalValue).SetInt(1)

        Decor.Unlock()
        Decor.Register(mosleyMod, Decor.eDecorType.Bool)
        Decor.Lock()
    End Sub

    Private Sub MosleyAuto_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        Try
            RegisterDecor(mosleyMod, Decor.eDecorType.Bool)

            veh = Game.Player.Character.LastVehicle
            ply = Game.Player.Character
            If veh.IsVehicleAttachedToTrailer Then tra = veh.GetVehicleTrailerVehicle

            'If Game.Player.IsAiming Then
            '    Dim aimat As New OutputArgument()
            '    If Native.Function.Call(Of Boolean)(Hash.GET_ENTITY_PLAYER_IS_FREE_AIMING_AT, Game.Player, aimat) Then
            '        Dim entity As Entity = aimat.GetResult(Of Entity)
            '        UI.ShowSubtitle($"Hash: {entity.Model.Hash} Position: {entity.Position.ToString}")
            '    End If
            'End If

            'Todo

            If HideHud Then
                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 3)
                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 4)
                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 5)
                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 13)
                Try
                    Dim camOutput As Tuple(Of Vector3, Vector3) = cameraSR.Update()
                    CameraPos = camOutput.Item1
                    CameraRot = camOutput.Item2
                Catch
                End Try
            End If

            If GetInteriorID(ply.Position) = mosleyIntID Then
                If Not IsArenaWarDLCInstalled() Then
                    DisplayHelpTextThisFrame("Un-supported GTA V version detected! Mosley Auto Service may not work properly on this version.")
                End If
            End If

            If GetInteriorID(ply.Position) = mosleyIntID AndAlso Not unWelcome.Contains(veh.ClassType) Then
                If Not isExiting AndAlso Not TestDrive = 3 Then
                    If veh.Position.DistanceTo(New Vector3(-22.02124, -1678.407, 28.89593)) <= 3 Then
                        PlayerVehicleHalt()
                        UpdateTitleName()
                        PlayEnterCutScene()
                        PutVehIntoShop()
                    Else
                        If veh.Position.DistanceTo(New Vector3(-11.1047, -1668.97, 28.90443)) <= 5 Then
                            If _menuPool.IsAnyMenuOpen Then
                                camera.Update()
                                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 3)
                                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 4)
                                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 5)
                                Native.Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, 13)
                            Else
                                UI.ShowHelpMessage(Game.GetGXTEntry("CMOD_TRIG").Replace("~a~", "~INPUT_CONTEXT~"), True)
                                If Game.IsControlPressed(0, Control.Context) Then PutVehIntoShop()
                            End If
                        End If
                    End If
                End If
                If isExiting Then
                    Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                    SuspendKeys()
                End If

                _menuPool.ProcessMenus()
                If Not veh = Nothing Then vehStats = GetVehicleStats(veh)
                _menuPool.UpdateStats(vehStats.TopSpeed, vehStats.Acceleration, vehStats.Braking, vehStats.Traction)

                If mUpgradeAW.Visible Then
                    Dim spr As New Sprite("aw_upg_vehs", arenaVehImage, mUpgradeAW.GetUIMenuOffset, New Size(431, 216), 0F, Color.White) : spr.Draw()
                End If

                If _menuPool.IsAnyMenuOpen Then
                    Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                    If BtnZoom.Text = "NULL" Then BtnZoom.Text = Game.GetGXTEntry("INPUT_CREATOR_ZOOM_IN_DISPLAYONLY")
                    If BtnZoomOut.Text = "NULL" Then BtnZoom.Text = Game.GetGXTEntry("INPUT_CREATOR_ZOOM_OUT_DISPLAYONLY")
                    If BtnFirstPerson.Text = "NULL" Then BtnFirstPerson.Text = Game.GetGXTEntry("MO_ZOOM_FIRST")
                End If

                If isRepairing Then
                    _menuPool.CloseAllMenus()
                    MainMenu.Visible = True
                    isRepairing = False
                End If

                Select Case True
                    Case _menuPool.IsAnyMenuOpen()
                        SuspendKeys()
                End Select
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try

        If _menuPool.IsAnyMenuOpen Then
            If Game.IsControlPressed(0, zinKey) Then
                Dim max As New PointF(6.0F + camera.Dimension, 3.0F + camera.Dimension)
                If Not camera.CameraZoom <= max.Y Then
                    camera.CameraZoom -= 0.1
                Else
                    camera.CameraZoom = max.Y
                End If
            End If
            If Game.IsControlPressed(0, zoutKey) Then
                Dim max As New PointF(6.0F + camera.Dimension, 3.0F + camera.Dimension)
                If Not camera.CameraZoom >= max.X Then
                    camera.CameraZoom += 0.1
                Else
                    camera.CameraZoom = max.X
                End If
            End If

            If Game.IsControlJustReleased(0, fpcKey) Then
                lastCameraPos = camera.MainCameraPosition
                If camera.MainCameraPosition = CameraPosition.Interior Then
                    If lastCameraPos = CameraPosition.Interior Then
                        camera.MainCameraPosition = CameraPosition.Car
                    Else
                        camera.MainCameraPosition = lastCameraPos
                    End If
                Else
                    camera.MainCameraPosition = CameraPosition.Interior
                End If
            End If
        End If
    End Sub

    Private Sub MosleyAuto_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        mosleyBlip.Remove()
        Game.FadeScreenIn(1000)
        If Not mosleyPed = Nothing Then mosleyPed.Delete()
        World.DestroyAllCameras()
        World.RenderingCamera = Nothing
    End Sub
End Class
