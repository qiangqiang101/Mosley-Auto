Imports System.Drawing
Imports GTA
Imports GTA.Native
Imports GTA.Math
Imports INMNativeUI
Imports Metadata

Public Class Showroom
    Inherits Script

    Public Sub New()
        BtnDoor = New InstructionalButton(doorKey, Game.GetGXTEntry("CMM_MOD_S6")) 'Door
        BtnRoof = New InstructionalButton(roofKey, Game.GetGXTEntry("CMOD_MOD_ROF")) 'Roof

        _menuPoolSR = New MenuPool()

        CreateSRMenus()
        Native.Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "VEHICLE_SHOP_HUD_1", False, -1)
        Native.Function.Call(Hash.REQUEST_SCRIPT_AUDIO_BANK, "VEHICLE_SHOP_HUD_2", False, -1)
    End Sub

    Private Sub Showroom_Tick(sender As Object, e As EventArgs) Handles Me.Tick
        Try
            srDoorDist = World.GetDistance(ply.Position, srDoor)
            Select Case ply.Name
                Case "Michael", "Franklin", "Trevor"
                    PlayerCash = Game.Player.Money
                Case Else
                    PlayerCash = 1999999999
            End Select

            If GetInteriorID(ply.Position) = mosleyIntID Then
                SpawnPed(PedHash.Hipster01AFY, pdmPed, srDoor, 139.4474)
                SpawnVehicle(parkBike1, bike1, bPos1, bRot1)
                SpawnVehicle(parkBike2, bike2, bPos2, bRot2)
                SpawnVehicle(parkBike3, bike3, bPos3, bRot3)
                SpawnVehicle(parkBike4, bike4, bPos4, bRot4)
                SpawnVehicle(parkCar1, car1, cPos1, cRot1)
                SpawnVehicle(parkCar2, car2, cPos2, cRot2)
                SpawnVehicle(parkCar3, car3, cPos3, cRot3)
                SpawnVehicle(parkCar4, car4, cPos4, cRot4)
                SpawnVehicle(parkCar5, car5, cPos5, cRot5)
                SpawnVehicle(parkCar6, car6, cPos6, cRot6)
                SpawnVehicle(parkCar7, car7, cPos7, cRot7)
                SpawnVehicle(parkCar8, car8, cPos8, cRot8)
                SpawnVehicle(parkCar9, car9, cPos9, cRot9)
                SpawnVehicle(parkCar10, car10, cPos10, cRot10)
                SpawnVehicle(parkCar11, car11, cPos11, cRot11)

                If ply.IsInVehicle Then
                    If ply.CurrentVehicle.GetBool(mosleyMod) Then ply.CurrentVehicle.SetBool(mosleyMod, False)
                End If

                If isExiting Then
                    Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                    Game.DisableAllControlsThisFrame(0)
                    'SuspendKeys()
                End If
            Else
                DeletePed(pdmPed)
                DeleteVehicle(bike1)
                DeleteVehicle(bike2)
                DeleteVehicle(bike3)
                DeleteVehicle(bike4)
                DeleteVehicle(car1)
                DeleteVehicle(car2)
                DeleteVehicle(car3)
                DeleteVehicle(car4)
                DeleteVehicle(car5)
                DeleteVehicle(car6)
                DeleteVehicle(car7)
                DeleteVehicle(car8)
                DeleteVehicle(car9)
                DeleteVehicle(car10)
                DeleteVehicle(car11)
            End If

            If Not ply.IsInVehicle AndAlso Not ply.IsDead AndAlso srDoorDist < 3.0 AndAlso Game.Player.WantedLevel = 0 AndAlso TaskScriptStatus = -1 Then
                DisplayHelpTextThisFrame(Game.GetGXTEntry("SHR_MENU")) 'GetLangEntry("HELP_ENTER_SHOP"))
            ElseIf Not ply.IsInVehicle AndAlso Not ply.IsDead AndAlso srDoorDist < 3.0 AndAlso Game.Player.WantedLevel >= 1 Then
                Native.Function.Call(Hash.DISPLAY_HELP_TEXT_THIS_FRAME, New InputArgument() {"LOSE_WANTED", 0})
            End If

            If TestDrive = 3 AndAlso Not ply.IsInVehicle Then
                Game.FadeScreenOut(200)
                Wait(200)
                Dim penalty As Double = VehiclePrice / 99
                If VehPreview.HasBeenDamagedBy(ply) Then
                    Game.Player.Money = (PlayerCash - (VehiclePrice / 99))
                    DisplayHelpTextThisFrame("$" & System.Math.Round(penalty).ToString("###,###") & GetLangEntry("HELP_PENALTY"))
                    UI.Notify("$" & System.Math.Round(penalty).ToString("###,###") & GetLangEntry("HELP_PENALTY"))
                End If
                ConfirmMenu.Visible = True
                VehPreview.IsDriveable = False
                VehPreview.LockStatus = VehicleLockStatus.CannotBeTriedToEnter
                VehPreview.Position = VehPreviewPos
                VehPreview.Heading = 138.1586
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, VehPreview, False)
                Native.Function.Call(Hash.SET_VEHICLE_FIXED, VehPreview)
                ply.Position = PlayerLastPos
                TestDrive = 1
                HideHud = True
                Wait(200)
                Game.FadeScreenIn(200)
                ShowVehicleName = True
                cameraSR.RepositionFor(VehPreview, CameraPos, CameraRot)
            ElseIf TestDrive = 3 AndAlso GetInteriorID(ply.Position) <> mosleyIntID Then
                Game.FadeScreenOut(200)
                Wait(200)
                Dim penalty As Double = VehiclePrice / 99
                If VehPreview.HasBeenDamagedBy(ply) Then
                    Game.Player.Money = (PlayerCash - (VehiclePrice / 99))
                    UI.Notify("$" & System.Math.Round(penalty).ToString("###,###") & GetLangEntry("HELP_PENALTY"))
                End If
                ConfirmMenu.Visible = True
                VehPreview.IsDriveable = False
                VehPreview.LockStatus = VehicleLockStatus.CannotBeTriedToEnter
                VehPreview.Position = VehPreviewPos
                VehPreview.Heading = 138.1586
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, VehPreview, False)
                Native.Function.Call(Hash.SET_VEHICLE_FIXED, VehPreview)
                ply.Position = PlayerLastPos
                TestDrive = 1
                HideHud = True
                Wait(200)
                Game.FadeScreenIn(200)
                ShowVehicleName = True
                cameraSR.RepositionFor(VehPreview, CameraPos, CameraRot)
            ElseIf TestDrive = 2 AndAlso ply.IsInVehicle Then
                TestDrive = TestDrive + 1
            End If

            If Game.IsControlJustPressed(0, GTA.Control.Context) AndAlso srDoorDist < 3.0 AndAlso Not ply.IsInVehicle AndAlso Game.Player.WantedLevel = 0 AndAlso TaskScriptStatus = -1 Then
                TaskScriptStatus = 0
                HideHud = True
                Wait(200)
                Game.FadeScreenIn(200)
                SelectedVehicle = optLastVehName
                PlayerLastPos = ply.Position
                If VehPreview = Nothing Then
                    VehPreview = World.CreateVehicle(New Model(optLastVehHash), VehPreviewPos, 138.1586)
                Else
                    VehPreview.Delete()
                    VehPreview = World.CreateVehicle(New Model(optLastVehHash), VehPreviewPos, 138.1586)
                End If
                UpdateVehPreview()
                cameraSR.RepositionFor(VehPreview, CameraPos, CameraRot)
                VehicleName = SelectedVehicle
                ShowVehicleName = True
                VehPreview.Heading = 138.1586
                VehPreview.LockStatus = VehicleLockStatus.CannotBeTriedToEnter
                VehPreview.DirtLevel = 0
                SRMainMenu.Visible = True
            End If

            If _menuPoolSR.IsAnyMenuOpen Then
                If Game.IsControlJustReleased(0, doorKey) AndAlso TaskScriptStatus = 0 Then
                    If VehPreview.IsDoorOpen(VehicleDoor.FrontLeftDoor) Then
                        Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, VehPreview, False)
                    Else
                        VehPreview.OpenDoor(VehicleDoor.BackLeftDoor, False, False)
                        VehPreview.OpenDoor(VehicleDoor.BackRightDoor, False, False)
                        VehPreview.OpenDoor(VehicleDoor.FrontLeftDoor, False, False)
                        VehPreview.OpenDoor(VehicleDoor.FrontRightDoor, False, False)
                        VehPreview.OpenDoor(VehicleDoor.Hood, False, False)
                        VehPreview.OpenDoor(VehicleDoor.Trunk, False, False)
                    End If
                End If
                If Game.IsControlJustPressed(0, roofKey) AndAlso TaskScriptStatus = 0 Then
                    If VehPreview.RoofState = VehicleRoofState.Closed Then
                        Native.Function.Call(Hash.LOWER_CONVERTIBLE_ROOF, VehPreview, False)
                    Else
                        Native.Function.Call(Hash.RAISE_CONVERTIBLE_ROOF, VehPreview, False)
                    End If
                End If
                If Game.IsControlPressed(0, zinKey) Then
                    Dim max As New PointF(6.0F + cameraSR.Dimension, 3.0F + cameraSR.Dimension)
                    If Not cameraSR.CameraZoom <= max.Y Then
                        cameraSR.CameraZoom -= 0.1
                    Else
                        cameraSR.CameraZoom = max.Y
                    End If
                End If
                If Game.IsControlPressed(0, zoutKey) Then
                    Dim max As New PointF(6.0F + cameraSR.Dimension, 3.0F + cameraSR.Dimension)
                    If Not cameraSR.CameraZoom >= max.X Then
                        cameraSR.CameraZoom += 0.1
                    Else
                        cameraSR.CameraZoom = max.X
                    End If
                End If
                If Game.IsControlJustReleased(0, fpcKey) Then
                    If Not VehPreview.ClassType = VehicleClass.Motorcycles Then
                        If cameraSR.MainCameraPosition = CameraPosition.Car Then
                            cameraSR.MainCameraPosition = CameraPosition.Interior2
                        Else
                            cameraSR.MainCameraPosition = CameraPosition.Car
                        End If
                    End If
                End If

                If ShowVehicleName = True AndAlso Not VehicleName = Nothing AndAlso TaskScriptStatus = 0 Then
                    Dim sr = Size.Round(UIMenu.GetScreenResolutionMaintainRatio)
                    Dim sz = UIMenu.GetSafezoneBounds
                    Dim vname As String = $"{VehPreview.Brand} {VehPreview.FriendlyName}"
                    Dim vclass As String = GetClassDisplayName(VehPreview.ClassType)

                    Select Case Game.Language
                        Case Language.Chinese, Language.Japanese, Language.Korean, Language.ChineseSimplified
                            Dim vn As New UIResText(vname, New Point(sr.Width - sz.X - 100, sr.Height - sz.Y - 240), 2.0F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Right) With {.DropShadow = True} : vn.Draw()
                            Dim vc As New UIResText(vclass, New Point(sr.Width - sz.X, sr.Height - sz.Y - 170), 2.0F, Color.DodgerBlue, GTA.Font.HouseScript, UIResText.Alignment.Right) With {.DropShadow = True} : vc.Draw()
                        Case Else
                            Dim vn As New UIResText(vname, New Point(sr.Width - sz.X - 100, sr.Height - sz.Y - 240), 2.0F, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Right) With {.DropShadow = True} : vn.Draw()
                            Dim vc As New UIResText(vclass, New Point(sr.Width - sz.X, sr.Height - sz.Y - 170), 2.0F, Color.DodgerBlue, GTA.Font.HouseScript, UIResText.Alignment.Right) With {.DropShadow = True} : vc.Draw()
                    End Select
                End If

                SuspendKeys()
            End If

            _menuPoolSR.ProcessMenus()
            vehStats = GetVehicleStats(VehPreview)
            _menuPoolSR.UpdateStats(vehStats.TopSpeed, vehStats.Acceleration, vehStats.Braking, vehStats.Traction)

            If isCutscene Then
                SuspendKeys()
                Native.Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME)
                Dim sr = Size.Round(UIMenu.GetScreenResolutionMaintainRatio)
                Dim sz = UIMenu.GetSafezoneBounds
                Dim vname As String = $"{veh.Brand} {veh.FriendlyName}"
                Dim vclass As String = GetClassDisplayName(veh.ClassType)

                Select Case Game.Language
                    Case Language.Chinese, Language.Japanese, Language.Korean, Language.ChineseSimplified
                        Dim vn As New UIResText(vname, New Point(sr.Width - sz.X - 100, sr.Height - sz.Y - 240), 2.0F, Color.White, GTA.Font.ChaletLondon, UIResText.Alignment.Right) With {.DropShadow = True} : vn.Draw()
                        Dim vc As New UIResText(vclass, New Point(sr.Width - sz.X, sr.Height - sz.Y - 170), 2.0F, Color.DodgerBlue, GTA.Font.HouseScript, UIResText.Alignment.Right) With {.DropShadow = True} : vc.Draw()
                    Case Else
                        Dim vn As New UIResText(vname, New Point(sr.Width - sz.X - 100, sr.Height - sz.Y - 240), 2.0F, Color.White, GTA.Font.ChaletComprimeCologne, UIResText.Alignment.Right) With {.DropShadow = True} : vn.Draw()
                        Dim vc As New UIResText(vclass, New Point(sr.Width - sz.X, sr.Height - sz.Y - 170), 2.0F, Color.DodgerBlue, GTA.Font.HouseScript, UIResText.Alignment.Right) With {.DropShadow = True} : vc.Draw()
                End Select
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Private Sub Showroom_Aborted(sender As Object, e As EventArgs) Handles Me.Aborted
        Game.FadeScreenIn(200)
        If Not pdmPed = Nothing Then pdmPed.Delete()
        If Not car1 = Nothing Then car1.Delete()
        If Not car2 = Nothing Then car2.Delete()
        If Not car3 = Nothing Then car3.Delete()
        If Not car4 = Nothing Then car4.Delete()
        If Not car5 = Nothing Then car5.Delete()
        If Not car6 = Nothing Then car6.Delete()
        If Not car7 = Nothing Then car7.Delete()
        If Not car8 = Nothing Then car8.Delete()
        If Not car9 = Nothing Then car9.Delete()
        If Not car10 = Nothing Then car10.Delete()
        If Not car11 = Nothing Then car11.Delete()
        If Not bike1 = Nothing Then bike1.Delete()
        If Not bike2 = Nothing Then bike2.Delete()
        If Not bike3 = Nothing Then bike3.Delete()
        If Not bike4 = Nothing Then bike4.Delete()
    End Sub

End Class
