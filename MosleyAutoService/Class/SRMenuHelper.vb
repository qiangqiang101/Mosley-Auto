Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Text
Imports GTA
Imports GTA.Math
Imports GTA.Native
Imports INMNativeUI

Public Module SRMenuHelper

    Public SRMainMenu, ConfirmMenu, CustomiseMenu, VehicleMenu As UIMenu
    Public itemCat As UIMenuItem
    Public PriColorMenu, ClassicColorMenu, MetallicColorMenu, MetalColorMenu, MatteColorMenu, ChromeColorMenu, PeaColorMenu, CPriColorMenu As UIMenu
    Public ColorMenu, SecColorMenu, ClassicColorMenu2, MetallicColorMenu2, MetalColorMenu2, MatteColorMenu2, ChromeColorMenu2, CSecColorMenu, PlateMenu As UIMenu

    Public ItemCustomize, ItemConfirm, ItemColor, ItemClassicColor, ItemClassicColor2, ItemMetallicColor, ItemMetallicColor2, ItemMetalColor, ItemMetalColor2,
        ItemMatteColor, ItemMatteColor2, ItemChromeColor, ItemChromeColor2, ItemCPriColor, ItemCSecColor, ItemPriColor, ItemSecColor, ItemPeaColor, ItemPlate As UIMenuItem

    Public Parameters As String() = {"[name]", "[price]", "[model]", "[gxt]", "[make]"}

    Public Sub CreateSRMenus()
        ItemCustomize = New UIMenuItem(GetLangEntry("BTN_CUSTOMIZE"))
        ItemConfirm = New UIMenuItem(Game.GetGXTEntry("ITEM_YES"))
        ItemColor = New UIMenuItem(Game.GetGXTEntry("IB_COLOR"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemClassicColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_1"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemClassicColor2 = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_1"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMetallicColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_3"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMetallicColor2 = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_3"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMetalColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_4"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMetalColor2 = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_4"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMatteColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_5"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemMatteColor2 = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_5"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemChromeColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_0"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemChromeColor2 = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_0"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemCPriColor = New UIMenuItem(GetLangEntry("BTN_CUSTOM_PRIMARY"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemCSecColor = New UIMenuItem(GetLangEntry("BTN_CUSTOM_SECONDARY"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemPriColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL0_0"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemSecColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL0_1"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemPeaColor = New UIMenuItem(Game.GetGXTEntry("CMOD_COL1_6"), Game.GetGXTEntry("CMOD_MOD_6_D"))
        ItemPlate = New UIMenuItem(Game.GetGXTEntry("CMOD_MOD_PLA"), Game.GetGXTEntry("CMOD_MOD_6_D"))

        CreateCategoryMenu()
        CreateConfirmMenu()
        CreateCustomizeMenu()
        CreateColorCategory()
        PlateMenu = PlateMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_MOD_PLA"), CustomiseMenu, ItemPlate)
        CreatePrimaryColor()
        CreateSecondaryColor()
        CPriColorMenu = CPriColorMenu.NewSRUIMenu(GetLangEntry("BTN_CUSTOM_PRIMARY"), ColorMenu, ItemCPriColor)
        CSecColorMenu = CSecColorMenu.NewSRUIMenu(GetLangEntry("BTN_CUSTOM_SECONDARY"), ColorMenu, ItemCSecColor)
        ClassicColorMenu = ClassicColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_1"), PriColorMenu, ItemClassicColor)
        MetallicColorMenu = MetallicColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_3"), PriColorMenu, ItemMetallicColor)
        MetalColorMenu = MetalColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_4"), PriColorMenu, ItemMetalColor)
        MatteColorMenu = MatteColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_5"), PriColorMenu, ItemMatteColor)
        ChromeColorMenu = ChromeColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_0"), PriColorMenu, ItemChromeColor)
        PeaColorMenu = PeaColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_6"), PriColorMenu, ItemPeaColor)
        ClassicColorMenu2 = ClassicColorMenu2.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_1"), SecColorMenu, ItemClassicColor2)
        MetallicColorMenu2 = MetallicColorMenu2.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_3"), SecColorMenu, ItemMetallicColor2)
        MetalColorMenu2 = MetalColorMenu2.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_4"), SecColorMenu, ItemMetalColor2)
        MatteColorMenu2 = MatteColorMenu2.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_5"), SecColorMenu, ItemMatteColor2)
        ChromeColorMenu2 = ChromeColorMenu2.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_0"), SecColorMenu, ItemChromeColor2)
    End Sub

    Public Sub CreateCategoryMenu()
        SRMainMenu = SRMainMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_MOD_T"), True)
        For Each file As String In IO.Directory.GetFiles(".\scripts\MosleyAutoService\Vehicles\", "*.ini")
            If IO.File.Exists(file) Then
                itemCat = New UIMenuItem(GetLangEntry(IO.Path.GetFileNameWithoutExtension(file)))
                With itemCat
                    Dim lc As Integer = IO.File.ReadAllLines(file).Length
                    .SubInteger1 = lc
                    .SubString1 = IO.Path.GetFileNameWithoutExtension(file)
                End With
                SRMainMenu.AddItem(itemCat)
            End If
        Next
        SRMainMenu.RefreshIndex()
        AddHandler SRMainMenu.OnItemSelect, AddressOf CategoryItemSelectHandler
        AddHandler SRMainMenu.OnMenuClose, AddressOf MenuCloseHandler
    End Sub

    Public Sub CreateConfirmMenu()
        ConfirmMenu = ConfirmMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_MOD_T"), True)
        ConfirmMenu.AddItem(ItemCustomize)
        ConfirmMenu.AddItem(New UIMenuItem(GetLangEntry("BTN_TEST_DRIVE")))
        ConfirmMenu.AddItem(New UIMenuItem(Game.GetGXTEntry("ITEM_YES")))
        ConfirmMenu.RefreshIndex()
        AddHandler ConfirmMenu.OnMenuClose, AddressOf ConfirmCloseHandler
        AddHandler ConfirmMenu.OnItemSelect, AddressOf ItemSelectHandler
    End Sub

    Public Sub CreateCustomizeMenu()
        CustomiseMenu = CustomiseMenu.NewSRUIMenu(GetLangEntry("BTN_CUSTOMIZE").ToUpper, True)
        CustomiseMenu.AddItem(ItemColor)
        CustomiseMenu.AddItem(New UIMenuItem(Game.GetGXTEntry("PERSO_MOD_PER"), Game.GetGXTEntry("IE_MOD_OBJ4"))) 'GetLangEntry("BTN_UPGRADE_NAME"), GetLangEntry("BTN_UPGRADE_DESC")))
        CustomiseMenu.AddItem(New UIMenuItem(GetLangEntry("BTN_PLATE_NUMBER_NAME"), Game.GetGXTEntry("IE_MOD_OBJ2"))) 'GetLangEntry("BTN_PLATE_NUMBER_NAME"), GetLangEntry("BTN_PLATE_NUMBER_DESC")))
        CustomiseMenu.AddItem(ItemPlate)
        CustomiseMenu.RefreshIndex()
        ConfirmMenu.BindMenuToItem(CustomiseMenu, ItemCustomize)
        AddHandler CustomiseMenu.OnItemSelect, AddressOf ItemSelectHandler
    End Sub

    Public Sub CreateColorCategory()
        ColorMenu = ColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL1_T"), True)
        ColorMenu.AddItem(ItemPriColor)
        ColorMenu.AddItem(ItemSecColor)
        ColorMenu.AddItem(ItemCPriColor)
        ColorMenu.AddItem(ItemCSecColor)
        ColorMenu.RefreshIndex()
        CustomiseMenu.BindMenuToItem(ColorMenu, ItemColor)
    End Sub

    Public Sub CreatePrimaryColor()
        PriColorMenu = PriColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL2_T"), True)
        PriColorMenu.AddItem(ItemClassicColor)
        PriColorMenu.AddItem(ItemMetallicColor)
        PriColorMenu.AddItem(ItemMatteColor)
        PriColorMenu.AddItem(ItemMetalColor)
        PriColorMenu.AddItem(ItemChromeColor)
        PriColorMenu.AddItem(ItemPeaColor)
        PriColorMenu.RefreshIndex()
        ColorMenu.BindMenuToItem(PriColorMenu, ItemPriColor)
    End Sub

    Public Sub CreateSecondaryColor()
        SecColorMenu = SecColorMenu.NewSRUIMenu(Game.GetGXTEntry("CMOD_COL3_T"), True)
        SecColorMenu.AddItem(ItemClassicColor2)
        SecColorMenu.AddItem(ItemMetallicColor2)
        SecColorMenu.AddItem(ItemMatteColor2)
        SecColorMenu.AddItem(ItemMetalColor2)
        SecColorMenu.AddItem(ItemChromeColor2)
        SecColorMenu.RefreshIndex()
        ColorMenu.BindMenuToItem(SecColorMenu, ItemSecColor)
    End Sub

    <Extension>
    Public Function NewSRUIMenu(ByRef menu As UIMenu, title As String, showStats As Boolean) As UIMenu
        Try
            menu = New UIMenu("", title, showStats)
            menu.SetBannerType(New Sprite("shopui_title_clubhousemod", "shopui_title_clubhousemod", Nothing, Nothing))
            menu.MouseEdgeEnabled = False
            menu.AddInstructionalButton(BtnZoom)
            menu.AddInstructionalButton(BtnZoomOut)
            menu.AddInstructionalButton(BtnFirstPerson)
            menu.AddInstructionalButton(BtnDoor)
            menu.AddInstructionalButton(BtnRoof)
            _menuPoolSR.Add(menu)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try

        Return menu
    End Function

    <Extension>
    Public Function NewSRUIMenu(ByRef menu As UIMenu, title As String, ByRef parentMenu As UIMenu, ByRef parentItem As UIMenuItem) As UIMenu
        Try
            menu = New UIMenu("", title, True)
            menu.SetBannerType(New Sprite("shopui_title_clubhousemod", "shopui_title_clubhousemod", Nothing, Nothing))
            menu.MouseEdgeEnabled = False
            menu.AddInstructionalButton(BtnZoom)
            menu.AddInstructionalButton(BtnZoomOut)
            menu.AddInstructionalButton(BtnFirstPerson)
            menu.AddInstructionalButton(BtnDoor)
            menu.AddInstructionalButton(BtnRoof)
            _menuPoolSR.Add(menu)
            menu.AddItem(New UIMenuItem("Nothing"))
            menu.RefreshIndex()
            parentMenu.BindMenuToItem(menu, parentItem)
            AddHandler menu.OnMenuClose, AddressOf SRModsMenuCloseHandler
            AddHandler menu.OnItemSelect, AddressOf SRModsMenuItemSelectHandler
            AddHandler menu.OnIndexChange, AddressOf SRModsMenuIndexChangedHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try

        Return menu
    End Function

    Public Sub MenuCloseHandler(sender As UIMenu)
        Try
            TaskScriptStatus = -1
            If SelectedVehicle IsNot Nothing Then
                SelectedVehicle = Nothing
                VehPreview.Delete()
            End If
            cameraSR.Stop()
            DrawSpotLight = False
            HideHud = False
            VehicleName = Nothing
            ShowVehicleName = False
            CustomiseMenu.RefreshIndex()
            ConfirmMenu.RefreshIndex()
            SRMainMenu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ConfirmCloseHandler(sender As UIMenu)
        Try
            SRMainMenu.Visible = True
            CustomiseMenu.RefreshIndex()
            ConfirmMenu.RefreshIndex()
            SRMainMenu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshSRColorMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef colorList As List(Of VehicleColor), prisecpear As String)
        Try
            menu.MenuItems.Clear()
            For Each col As VehicleColor In colorList
                item = New UIMenuItem(GetLocalizedColorName(col))
                With item
                    .SubInteger1 = col
                    If prisecpear = "Primary" Then
                        If VehPreview.PrimaryColor = col Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    ElseIf prisecpear = "Secondary" Then
                        If VehPreview.SecondaryColor = col Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    ElseIf prisecpear = "Pearlescent" Then
                        If VehPreview.PearlescentColor = col Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshSRRGBColorMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, category As String)
        Try
            menu.MenuItems.Clear()
            Dim removeList As New List(Of String) From {"R", "G", "B", "A", "IsKnownColor", "IsEmpty", "IsNamedColor", "IsSystemColor", "Name", "Transparent"}
            Dim index As Integer = 0
            For Each col As Reflection.PropertyInfo In GetType(Drawing.Color).GetProperties()
                If Not removeList.Contains(col.Name) Then
                    item = New UIMenuItem(Trim(RegularExpressions.Regex.Replace(col.Name, "[A-Z]", " ${0}")))
                    With item
                        .SubInteger1 = Drawing.Color.FromName(col.Name).R
                        .SubInteger2 = Drawing.Color.FromName(col.Name).G
                        .SubInteger3 = Drawing.Color.FromName(col.Name).B
                        If category = "Primary" Then
                            If VehPreview.CustomPrimaryColor = Drawing.Color.FromName(col.Name) Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        ElseIf category = "Secondary" Then
                            If VehPreview.CustomSecondaryColor = Drawing.Color.FromName(col.Name) Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End If
                    End With
                    menu.AddItem(item)
                End If
            Next

            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshSREnumModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef enumType As EnumTypes)
        Try
            menu.MenuItems.Clear()

            Dim enumArray As Array = Nothing
            Select Case enumType
                Case EnumTypes.NumberPlateType
                    enumArray = System.Enum.GetValues(GetType(NumberPlateType))
                    For Each enumItem As NumberPlateType In enumArray
                        item = New UIMenuItem(LocalizedLicensePlate(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If VehPreview.NumberPlateType = enumItem Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleWindowTint
                    enumArray = System.Enum.GetValues(GetType(VehicleWindowTint))
                    For Each enumItem As VehicleWindowTint In enumArray
                        item = New UIMenuItem(LocalizedWindowsTint(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If VehPreview.WindowTint = enumItem Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorTrim
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If VehPreview.TrimColor = enumItem Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorDashboard
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If VehPreview.DashboardColor = enumItem Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorRim
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If VehPreview.RimColor = enumItem Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        End With
                        menu.AddItem(item)
                    Next
            End Select
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub VehicleSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If selectedItem.Text = VehicleName Then 'If VehPreview.Exists() = True Then
            sender.Visible = False
            ConfirmMenu.Visible = True
            VehicleName = selectedItem.Text
            optLastVehMake = selectedItem.SubString3
            ShowVehicleName = True
            RefreshSRRGBColorMenuFor(CPriColorMenu, New UIMenuItem("nothing"), "Primary")
            RefreshSRRGBColorMenuFor(CSecColorMenu, New UIMenuItem("nothing"), "Secondary")
            RefreshSRColorMenuFor(ClassicColorMenu, New UIMenuItem("nothing"), ClassicColor, "Primary")
            RefreshSRColorMenuFor(MetallicColorMenu, New UIMenuItem("nothing"), ClassicColor, "Primary")
            RefreshSRColorMenuFor(MetalColorMenu, New UIMenuItem("nothing"), MetalColor, "Primary")
            RefreshSRColorMenuFor(MatteColorMenu, New UIMenuItem("nothing"), MatteColor, "Primary")
            RefreshSRColorMenuFor(ChromeColorMenu, New UIMenuItem("nothing"), ChromeColor, "Primary")
            RefreshSRColorMenuFor(PeaColorMenu, New UIMenuItem("nothing"), PearlescentColor, "Pearlescent")
            RefreshSRColorMenuFor(ClassicColorMenu2, New UIMenuItem("nothing"), ClassicColor, "Secondary")
            RefreshSRColorMenuFor(MetallicColorMenu2, New UIMenuItem("nothing"), ClassicColor, "Secondary")
            RefreshSRColorMenuFor(MetalColorMenu2, New UIMenuItem("nothing"), MetalColor, "Secondary")
            RefreshSRColorMenuFor(MatteColorMenu2, New UIMenuItem("nothing"), MatteColor, "Secondary")
            RefreshSRColorMenuFor(ChromeColorMenu2, New UIMenuItem("nothing"), ChromeColor, "Secondary")
            RefreshSREnumModMenuFor(PlateMenu, New UIMenuItem("nothing"), EnumTypes.NumberPlateType)
        Else
            SelectedVehicle = selectedItem.SubString2
            If VehPreview = Nothing Then
                If Not selectedItem.Text.Contains("NULL") Then
                    If optFade = 1 Then
                        Game.FadeScreenOut(200)
                        Script.Wait(200)
                        VehPreview = World.CreateVehicle(New Model(selectedItem.SubString1), VehPreviewPos, 138.1586)
                        Script.Wait(200)
                        Game.FadeScreenIn(200)
                    Else
                        VehPreview = World.CreateVehicle(New Model(selectedItem.SubString1), VehPreviewPos, 138.1586)
                    End If
                End If
            Else
                VehPreview.Delete()
                If Not selectedItem.Text.Contains("NULL") Then
                    If optFade = 1 Then
                        Game.FadeScreenOut(200)
                        Script.Wait(200)
                        VehPreview = World.CreateVehicle(New Model(selectedItem.SubString1), VehPreviewPos, 138.1586)
                        Script.Wait(200)
                        Game.FadeScreenIn(200)
                    Else
                        VehPreview = World.CreateVehicle(New Model(selectedItem.SubString1), VehPreviewPos, 138.1586)
                    End If
                End If
            End If
            If optRandomColor = 1 Then
                Dim r As Random = New Random
                Dim psc As Integer = r.Next(0, 160)
                VehPreview.PrimaryColor = psc
                VehPreview.SecondaryColor = psc
                VehPreview.PearlescentColor = r.Next(0, 160)
                VehPreview.TrimColor = r.Next(0, 160)
                VehPreview.DashboardColor = r.Next(0, 160)
                VehPreview.RimColor = r.Next(0, 160)
            End If
            UpdateVehPreview()
            VehicleName = sender.MenuItems(index).Text
            optLastVehMake = sender.MenuItems(index).SubString3
            ShowVehicleName = True
            VehPreview.Heading = 138.1586
            VehPreview.IsDriveable = False
            VehPreview.LockStatus = VehicleLockStatus.CannotBeTriedToEnter
            VehPreview.DirtLevel = 0
            VehiclePrice = selectedItem.SubInteger1
            optLastVehHash = VehPreview.Model.Hash
            optLastVehName = VehicleName
            hiddenSave.SetValue(Of Integer)("SAVE", "LASTVEHHASH", VehPreview.Model.Hash)
            hiddenSave.SetValue(Of String)("SAVE", "LASTVEHNAME", VehicleName)
            hiddenSave.Save()
        End If
    End Sub

    Public Sub VehicleChangeHandler(sender As UIMenu, index As Integer)
        Try
            SelectedVehicle = sender.MenuItems(index).SubString2
            If VehPreview = Nothing Then
                If Not sender.MenuItems(index).Text.Contains("NULL") Then
                    If optFade = 1 Then
                        Game.FadeScreenOut(200)
                        Script.Wait(200)
                        VehPreview = World.CreateVehicle(New Model(sender.MenuItems(index).SubString1), VehPreviewPos, 138.1586)
                        Script.Wait(200)
                        Game.FadeScreenIn(200)
                    Else
                        VehPreview = World.CreateVehicle(New Model(sender.MenuItems(index).SubString1), VehPreviewPos, 138.1586)
                    End If
                End If
            Else
                VehPreview.Delete()
                If Not sender.MenuItems(index).Text.Contains("NULL") Then
                    If optFade = 1 Then
                        Game.FadeScreenOut(200)
                        Script.Wait(200)
                        VehPreview = World.CreateVehicle(New Model(sender.MenuItems(index).SubString1), VehPreviewPos, 138.1586)
                        Script.Wait(200)
                        Game.FadeScreenIn(200)
                    Else
                        VehPreview = World.CreateVehicle(New Model(sender.MenuItems(index).SubString1), VehPreviewPos, 138.1586)
                    End If
                End If
            End If
            If optRandomColor = 1 Then
                Dim r As Random = New Random
                Dim psc As Integer = r.Next(0, 160)
                VehPreview.PrimaryColor = psc
                VehPreview.SecondaryColor = psc
                VehPreview.PearlescentColor = r.Next(0, 160)
                VehPreview.TrimColor = r.Next(0, 160)
                VehPreview.DashboardColor = r.Next(0, 160)
                VehPreview.RimColor = r.Next(0, 160)
            End If
            UpdateVehPreview()
            VehicleName = sender.MenuItems(index).Text
            optLastVehMake = sender.MenuItems(index).SubString3
            ShowVehicleName = True
            VehPreview.Heading = 138.1586
            VehPreview.IsDriveable = False
            VehPreview.LockStatus = VehicleLockStatus.CannotBeTriedToEnter
            VehPreview.DirtLevel = 0
            VehiclePrice = sender.MenuItems(index).SubInteger1
            cameraSR.RepositionFor(VehPreview, CameraPos, CameraRot)
            optLastVehHash = VehPreview.Model.Hash
            optLastVehName = VehicleName
            hiddenSave.SetValue(Of Integer)("SAVE", "LASTVEHHASH", VehPreview.Model.Hash)
            hiddenSave.SetValue(Of String)("SAVE", "LASTVEHNAME", VehicleName)
            hiddenSave.Save()

            If hiddenSave.GetValue(Of Integer)("VEHICLES", VehPreview.Model.Hash, 0) = 0 Then
                hiddenSave.SetValue(Of Integer)("VEHICLES", VehPreview.Model.Hash, 1)
                hiddenSave.Save()
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If selectedItem.Text = Game.GetGXTEntry("ITEM_YES") Then 'GetLangEntry("BTN_CONFIRM") Then
                If PlayerCash > VehiclePrice Then
                    Game.FadeScreenOut(200)
                    Script.Wait(200)
                    Game.Player.Money = (PlayerCash - VehiclePrice)
                    ConfirmMenu.Visible = False
                    cameraSR.Stop()
                    DrawSpotLight = False
                    VehPreview.IsDriveable = True
                    VehPreview.LockStatus = VehicleLockStatus.Unlocked
                    Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, VehPreview, False)
                    VehPreview.Position = New Vector3(-34.23862, -1644.84, 28.84091)
                    VehPreview.Heading = 49.98999
                    Native.Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, ply, VehPreview, -1)
                    VehPreview.MarkAsNoLongerNeeded()
                    VehPreview = Nothing
                    HideHud = False
                    Script.Wait(200)
                    Game.FadeScreenIn(200)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "PROPERTY_PURCHASE", "HUD_AWARDS", False)
                    BigMessageThread.MessageInstance.ShowWeaponPurchasedMessage("~y~" & GetLangEntry("VEHICLE_PURCHASED"), "~w~" & SelectedVehicle, Nothing)
                    SelectedVehicle = Nothing
                    VehicleName = Nothing
                    ShowVehicleName = False
                    TaskScriptStatus = -1
                Else
                    If Game.Player.Character.Name = "Franklin" Then
                        DisplayNotificationThisFrame(Game.GetGXTEntry("EMSTR_55"), "", Game.GetGXTEntry("PI_BIK_HX8"), "CHAR_BANK_FLEECA", True, IconType.RightJumpingArrow)
                    ElseIf Game.Player.Character.Name = "Trevor" Then
                        DisplayNotificationThisFrame(Game.GetGXTEntry("EMSTR_58"), "", Game.GetGXTEntry("PI_BIK_HX8"), "CHAR_BANK_BOL", True, IconType.RightJumpingArrow)
                    Else
                        DisplayNotificationThisFrame(Game.GetGXTEntry("EMSTR_52"), "", Game.GetGXTEntry("PI_BIK_HX8"), "CHAR_BANK_MAZE", True, IconType.RightJumpingArrow)
                    End If
                End If
            ElseIf selectedItem.Text = GetLangEntry("BTN_TEST_DRIVE") Then
                Game.FadeScreenOut(200)
                Script.Wait(200)
                Native.Function.Call(Hash.TASK_WARP_PED_INTO_VEHICLE, ply, VehPreview, -1)
                ConfirmMenu.Visible = False
                cameraSR.Stop()
                DrawSpotLight = False
                VehPreview.IsDriveable = True
                VehPreview.LockStatus = VehicleLockStatus.Unlocked
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, VehPreview, False)
                DisplayHelpTextThisFrame(GetLangEntry("HELP_TEST_DRIVE"))
                TestDrive = TestDrive + 1
                HideHud = False
                VehPreview.Position = New Vector3(-34.23862, -1644.84, 28.84091)
                VehPreview.Heading = 49.98999
                Script.Wait(200)
                Game.FadeScreenIn(200)
                ShowVehicleName = False
            End If

            If selectedItem.Text = Game.GetGXTEntry("PERSO_MOD_PER") Then 'GetLangEntry("BTN_UPGRADE_NAME") Then
                VehPreview.InstallModKit()
                VehPreview.SetMod(VehicleMod.Suspension, VehPreview.GetModCount(VehicleMod.Suspension) - 1, False)
                VehPreview.SetMod(VehicleMod.Engine, VehPreview.GetModCount(VehicleMod.Engine) - 1, False)
                VehPreview.SetMod(VehicleMod.Brakes, VehPreview.GetModCount(VehicleMod.Brakes) - 1, False)
                VehPreview.SetMod(VehicleMod.Transmission, VehPreview.GetModCount(VehicleMod.Transmission) - 1, False)
                VehPreview.SetMod(VehicleMod.Armor, VehPreview.GetModCount(VehicleMod.Armor) - 1, False)
                VehPreview.ToggleMod(VehicleToggleMod.XenonHeadlights, True)
                VehPreview.ToggleMod(VehicleToggleMod.Turbo, True)
                Native.Function.Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, VehPreview, False)
                Native.Function.Call(Hash._START_SCREEN_EFFECT, "MP_corona_switch_supermod", 0, 1)
                Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lowrider_Upgrade", "Lowrider_Super_Mod_Garage_Sounds", 1)
            ElseIf selectedItem.Text = GetLangEntry("BTN_PLATE_NUMBER_NAME") Then
                Dim NumPlateText As String = Game.GetUserInput(VehPreview.NumberPlate, 9)
                If NumPlateText <> "" Then
                    VehPreview.NumberPlate = NumPlateText
                End If
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CategoryItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            CreateVehicleMenu($".\scripts\MosleyAutoService\Vehicles\{selectedItem.SubString1}.ini", GetLangEntry(selectedItem.SubString1))
            sender.Visible = Not sender.Visible
            VehicleMenu.Visible = Not VehicleMenu.Visible
            If selectedItem.SubInteger1 > 10 Then
                VehicleMenu.GoDownOverflow()
                VehicleMenu.GoUpOverflow()
            Else
                VehicleMenu.GoUp()
                VehicleMenu.GoDown()
            End If

            VehicleMenu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub CreateVehicleMenu(File As String, Subtitle As String)
        Try
            Dim Format As New Reader(File, Parameters)
            VehicleMenu = VehicleMenu.NewSRUIMenu(Subtitle.ToUpper, True)
            For ii As Integer = 0 To Format.Count - 1
                Dim i As Integer = (Format.Count - 1) - ii
                Price = Format(i)("price")
                Dim item As New UIMenuItem(Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt")))
                With item
                    If .Text.Contains("NULL") Then .Text = Game.GetGXTEntry(Format(i)("gxt"))
                    If .Text.Contains("NULL") Then .Text = Format(i)("name")
                    .SetRightLabel("$" & Price.ToString)
                    .SubString1 = Format(i)("model")
                    .SubInteger1 = Format(i)("price")
                    .SubString2 = Game.GetGXTEntry(Format(i)("make")) & " " & Game.GetGXTEntry(Format(i)("gxt"))
                    .SubString3 = Format(i)("make")
                    Dim model As Model = New Model(.SubString1)
                    If hiddenSave.GetValue(Of Integer)("VEHICLES", model.Hash, 0) = 0 Then
                        hiddenSave.SetValue(Of Integer)("VEHICLES", VehPreview.Model.Hash, 0)
                        .SetLeftBadge(UIMenuItem.BadgeStyle.Star)
                    End If
                End With
                Dim vmodel As Model = New Model(item.SubString1)
                If vmodel.IsInCdImage AndAlso vmodel.IsValid Then
                    VehicleMenu.AddItem(item)
                End If
            Next
            VehicleMenu.RefreshIndex()
            AddHandler VehicleMenu.OnItemSelect, AddressOf VehicleSelectHandler
            AddHandler VehicleMenu.OnIndexChange, AddressOf VehicleChangeHandler
            SRMainMenu.BindMenuToItem(VehicleMenu, itemCat)
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SRModsMenuIndexChangedHandler(sender As UIMenu, index As Integer)
        Try
            If (sender Is ClassicColorMenu) Or (sender Is ChromeColorMenu) Or (sender Is MatteColorMenu) Or (sender Is MetalColorMenu) Then
                VehPreview.PrimaryColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is MetallicColorMenu Then
                VehPreview.PrimaryColor = sender.MenuItems(index).SubInteger1
                VehPreview.PearlescentColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is PeaColorMenu Then
                VehPreview.PearlescentColor = sender.MenuItems(index).SubInteger1
            ElseIf (sender Is ClassicColorMenu2) Or (sender Is ChromeColorMenu2) Or (sender Is MatteColorMenu2) Or (sender Is MetalColorMenu2) Then
                VehPreview.SecondaryColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is MetallicColorMenu2 Then
                VehPreview.SecondaryColor = sender.MenuItems(index).SubInteger1
                VehPreview.PearlescentColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is CPriColorMenu Then
                VehPreview.CustomPrimaryColor = Color.FromArgb(sender.MenuItems(index).SubInteger1, sender.MenuItems(index).SubInteger2, sender.MenuItems(index).SubInteger3)
            ElseIf sender Is CSecColorMenu Then
                VehPreview.CustomSecondaryColor = Color.FromArgb(sender.MenuItems(index).SubInteger1, sender.MenuItems(index).SubInteger2, sender.MenuItems(index).SubInteger3)
            ElseIf sender Is PlateMenu Then
                VehPreview.NumberPlateType = sender.MenuItems(index).SubInteger1
            End If

            If optRemoveColor = 1 Then
                If sender Is CPriColorMenu Then
                    VehPreview.PrimaryColor = VehicleColor.MetallicBlack
                ElseIf sender Is CSecColorMenu Then
                    VehPreview.SecondaryColor = VehicleColor.MetallicBlack
                ElseIf sender.ParentMenu Is PriColorMenu Then
                    VehPreview.ClearCustomPrimaryColor()
                ElseIf sender.ParentMenu Is SecColorMenu Then
                    VehPreview.ClearCustomSecondaryColor()
                End If
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SRModsMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            For Each i As UIMenuItem In sender.MenuItems
                i.SetRightBadge(UIMenuItem.BadgeStyle.None)
            Next

            'Color
            If (sender Is ClassicColorMenu) Or (sender Is ChromeColorMenu) Or (sender Is MatteColorMenu) Or (sender Is MetalColorMenu) Then
                VehPreview.PrimaryColor = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.PrimaryColor = selectedItem.SubInteger1
            ElseIf sender Is MetallicColorMenu Then
                VehPreview.PrimaryColor = selectedItem.SubInteger1
                VehPreview.PearlescentColor = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.PrimaryColor = selectedItem.SubInteger1
                lastSRVehMemory.PearlescentColor = selectedItem.SubInteger1
            ElseIf sender Is PeaColorMenu Then
                VehPreview.PearlescentColor = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.PearlescentColor = selectedItem.SubInteger1
            ElseIf (sender Is ClassicColorMenu2) Or (sender Is ChromeColorMenu2) Or (sender Is MatteColorMenu2) Or (sender Is MetalColorMenu2) Then
                VehPreview.SecondaryColor = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.SecondaryColor = selectedItem.SubInteger1
            ElseIf sender Is MetallicColorMenu2 Then
                VehPreview.SecondaryColor = selectedItem.SubInteger1
                VehPreview.PearlescentColor = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.SecondaryColor = selectedItem.SubInteger1
                lastSRVehMemory.PearlescentColor = selectedItem.SubInteger1
            ElseIf sender Is CPriColorMenu Then
                VehPreview.CustomPrimaryColor = Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.CustomPrimaryColor = Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
            ElseIf sender Is CSecColorMenu Then
                VehPreview.CustomSecondaryColor = Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.CustomSecondaryColor = Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
            ElseIf sender Is PlateMenu Then
                VehPreview.NumberPlateType = selectedItem.SubInteger1
                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                lastSRVehMemory.NumberPlate = selectedItem.SubInteger1
            End If

            If optRemoveColor = 1 Then
                If sender Is CPriColorMenu Then
                    VehPreview.PrimaryColor = VehicleColor.MetallicBlack
                ElseIf sender Is CSecColorMenu Then
                    VehPreview.SecondaryColor = VehicleColor.MetallicBlack
                ElseIf sender.ParentMenu Is PriColorMenu Then
                    VehPreview.ClearCustomPrimaryColor()
                ElseIf sender.ParentMenu Is SecColorMenu Then
                    VehPreview.ClearCustomSecondaryColor()
                End If
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub SRModsMenuCloseHandler(sender As UIMenu)
        Try
            VehPreview.PrimaryColor = lastSRVehMemory.PrimaryColor
            VehPreview.SecondaryColor = lastSRVehMemory.SecondaryColor
            VehPreview.PearlescentColor = lastSRVehMemory.PearlescentColor
            VehPreview.NumberPlateType = lastSRVehMemory.NumberPlate

            If optRemoveColor = 1 Then
                If sender Is CPriColorMenu Then
                    VehPreview.PrimaryColor = VehicleColor.MetallicBlack
                ElseIf sender Is CSecColorMenu Then
                    VehPreview.SecondaryColor = VehicleColor.MetallicBlack
                ElseIf sender.ParentMenu Is PriColorMenu Then
                    VehPreview.ClearCustomPrimaryColor()
                ElseIf sender.ParentMenu Is SecColorMenu Then
                    VehPreview.ClearCustomSecondaryColor()
                End If
            End If

            If sender Is CPriColorMenu Then VehPreview.CustomPrimaryColor = lastSRVehMemory.CustomPrimaryColor
            If sender Is CSecColorMenu Then VehPreview.CustomSecondaryColor = lastSRVehMemory.CustomSecondaryColor
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

End Module
