﻿Imports System.Runtime.CompilerServices
Imports System.Text
Imports GTA
Imports GTA.Native
Imports INMNativeUI
Imports Metadata

Module MenuHelper

    Public QuitMenu, MainMenu, gmBodywork, gmBodyworkArena, gmEngine, gmInterior, gmPlate, gmLights, gmRespray, gmWheels, gmBumper, gmWheelType, gmNeonKits, gmWeapon As UIMenu
    Public mAerials, mSuspension, mArmor, mBrakes, mEngine, mTransmission, mFBumper, mRBumper, mSSkirt, mTrim, mEngineBlock, mAirFilter, mStruts, mColumnShifterLevers, mDashboard, mDialDesign, mOrnaments, mSeats,
        mSteeringWheels, mTrimDesign, mPlateHolder, mVanityPlates, mNumberPlate, gmBikeWheels, gmHighEnd, gmLowrider, gmMuscle, gmOffroad, gmSport, gmSUV, gmTuner, mBennysOriginals, mBespoke, mTires, mHeadlights, mNeon, mNeonColor,
    mArchCover, mExhaust, mFender, mRFender, mDoor, mFrame, mGrille, mHood, mHorn, mHydraulics, mLivery, mPlaques, mRoof, mSpeakers, mSpoilers, mTank, mTrunk, mWindow, mTurbo, mTint, mLightsColor, mTrimColor, mRimColor,
    mPrimaryClassicColor, mPrimaryChromeColor, mPrimaryMetallicColor, mPrimaryMetalsColor, mPrimaryMatteColor, mPrimaryPearlescentColor, mPrimaryColor, mSecondaryColor, mSecondaryClassicColor, mSecondaryChromeColor,
    mSecondaryMetallicColor, mSecondaryMetalsColor, mSecondaryMatteColor, mTireSmoke, mTornadoC, mSBikeWheels, mCBikeWheels, mSHighEnd, mCHighEnd, mSLowrider, mCLowrider, mSMuscle, mCMuscle, mSOffroad, mCOffroad,
    mSSport, mCSport, mSSUV, mCSUV, mSTuner, mCTuner, mUpgradeAW, mNitro As UIMenu
    Public iRepair, iHorn, iArmor, iBrakes, iFBumper, iExhaust, iFender, iRollcage, iRoof, iTransmission, iEngine, iPlate, iLights, iTint, iTurbo, iRespray, iWheels, iSuspension, iEngineBlock, iAerials, iAirFilter,
        iArchCover, iDoor, iFrame, iGrille, iHood, iHydraulics, iLivery, iPlaques, iRFender, iSpeaker, iSpoilers, iTank, iTrunk, iWindows, iTrim, iUpgrade, iUpgradeMod, iUpgradeAW, iUpgradeAWV, iStruts, iTrimColor, iColumnShifterLevers, iDashboard, iDialDesign,
        iOrnaments, iSeats, iSteeringWheels, iTrimDesign, iRBumper, iSideSkirt, iRimColor, iPlateHolder, iVanityPlates, iHeadlights, iDashboardColor, iNumberPlate, iBikeWheels, iHighEnd, iLowrider, iMuscle, iOffroad,
        iSport, iSUV, iTuner, iBennys, iBespoke, iTires, iBPTires, iNeon, iTireSmoke, iNeonColor, iLightsColor, iPrimaryCol, iSecondaryCol, iPrimaryChromeColor, iPrimaryClassicColor, iPrimaryMetallicColor, iPrimaryMetalsColor,
        iPrimaryMatteColor, iPrimaryPearlescentColor, iSecondaryChromeColor, iSecondaryClassicColor, iSecondaryMetallicColor, iSecondaryMetalsColor, iSecondaryMatteColor, iSecondaryPearlescentColor, iTornadoC, iNitro As UIMenuItem
    Public giBodywork, giBodyworkArena, giEngine, giInterior, giPlate, giLights, giRespray, giWheels, giBumper, giWheelType, giTires, giNeonKits, giPrimaryCol, giSecondaryCol, giBikeWheels, giHighEndWheels, giDoor,
        giLowriderWheels, giMuscleWheels, giOffroadWheels, giSportWheels, giSUVWheels, giTunerWheels, giBennysWheels, giBespokeWheels, giFBumper, giRBumper, giSSkirt, giNumberPlate, giVanityPlate, giPlateHolder,
        giExhaust, giBrakes, giGrille, giHood, giHydraulics, giPlaques, giSpoilers, giTank, giTrunk, giStruts, iSBikeWheels, iCBikeWheels, iSHighEnd, iCHighEnd, iSLowrider, iCLowrider, iSMuscle, iCMuscle, iSOffroad, iCOffroad,
    iSSport, iCSport, iSSUV, iCSUV, iSTuner, iCTuner, giTrailer, giWeapon, giArchCover, giRoof, giAirfilter, giOrnaments As UIMenuItem
    Public iShifter, iFMudguard, iBSeat, iOilTank, iRMudguard, iFuelTank, iBeltDriveCovers, iBEngineBlock, iBAirFilter, iBTank As UIMenuItem
    Public giShifter, giFMudguard, giOilTank, giRMudguard, giFuelTank, giBeltDriveCovers, giBEngineBlock, giBAirFilter, giBTank As UIMenuItem
    Public mShifter, mFMudguard, mBSeat, mOilTank, mRMudguard, mFuelTank, mBeltDriveCovers, mBEngineBlock, mBAirFilter, mBTank, gmTrailer As UIMenu

#Region "Refresh Menus"
    Public Sub RefreshMenus()
        If arenavehicle.Contains(veh.Model) Then
            RefreshBodyworkArenaMenu()
            RefreshWeaponMenu()
        ElseIf arenawar.Contains(veh.Model) Then
            RefreshArenaWarMenu()
        Else
            RefreshBodyworkMenu()
        End If
        RefreshModMenuFor(mAerials, iAerials, VehicleMod.Aerials)
        RefreshModMenuFor(mTrim, iTrim, VehicleMod.Trim)
        RefreshModMenuFor(mWindow, iWindows, VehicleMod.Windows)
        RefreshModMenuFor(mArchCover, iArchCover, VehicleMod.ArchCover)
        RefreshEngineMenu()
        RefreshPerformanceMenuFor(mEngine, iEngine, VehicleMod.Engine, "CMOD_ENG_")
        RefreshNitroMenu()
        RefreshModMenuFor(mEngineBlock, iEngineBlock, VehicleMod.EngineBlock)
        RefreshModMenuFor(mAirFilter, iAirFilter, VehicleMod.AirFilter)
        RefreshModMenuFor(mStruts, iStruts, VehicleMod.Struts)
        RefreshInteriorMenu()
        RefreshModMenuFor(mColumnShifterLevers, iColumnShifterLevers, VehicleMod.ColumnShifterLevers)
        RefreshModMenuFor(mDashboard, iDashboard, VehicleMod.Dashboard)
        RefreshEnumModMenuFor(mLightsColor, iLightsColor, EnumTypes.VehicleColorDashboard)
        RefreshModMenuFor(mDialDesign, iDialDesign, VehicleMod.DialDesign)
        RefreshModMenuFor(mOrnaments, iOrnaments, VehicleMod.Ornaments)
        RefreshModMenuFor(mSeats, iSeats, VehicleMod.Seats)
        RefreshModMenuFor(mSteeringWheels, iSteeringWheels, VehicleMod.SteeringWheels)
        RefreshModMenuFor(mTrimDesign, iTrimDesign, VehicleMod.TrimDesign)
        RefreshEnumModMenuFor(mTrimColor, iTrimColor, EnumTypes.VehicleColorTrim)
        RefreshModMenuFor(mDoor, iDoor, VehicleMod.DoorSpeakers)
        RefreshBumperMenu()
        RefreshModMenuFor(mFBumper, iFBumper, VehicleMod.FrontBumper)
        RefreshModMenuFor(mRBumper, iRBumper, VehicleMod.RearBumper)
        RefreshModMenuFor(mSSkirt, iSideSkirt, VehicleMod.SideSkirt)
        RefreshWheelsMenu()
        RefreshWheelTypeMenu()

        RefreshWheelRimMenu(gmBikeWheels, mSBikeWheels, mCBikeWheels, iSBikeWheels, iCBikeWheels)
        'RefreshStockWheelsModMenuFor(mSBikeWheels, iSBikeWheels, VehicleMod.BackWheels)
        'RefreshChromeWheelsModMenuFor(mCBikeWheels, iCBikeWheels, VehicleMod.BackWheels)
        ''RefreshModMenuFor(gmBikeWheels, iBikeWheels, VehicleMod.BackWheels)
        RefreshBikeWheelsModMenuFor(mSBikeWheels, iSBikeWheels, VehicleMod.BackWheels, False)
        RefreshBikeWheelsModMenuFor(mCBikeWheels, iCBikeWheels, VehicleMod.BackWheels, True)

        RefreshWheelRimMenu(gmHighEnd, mSHighEnd, mCHighEnd, iSHighEnd, iCHighEnd)
        RefreshStockWheelsModMenuFor(mSHighEnd, iSHighEnd, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCHighEnd, iCHighEnd, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmLowrider, mSLowrider, mCLowrider, iSLowrider, iCLowrider)
        RefreshStockWheelsModMenuFor(mSLowrider, iSLowrider, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCLowrider, iCLowrider, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmMuscle, mSMuscle, mCMuscle, iSMuscle, iCMuscle)
        RefreshStockWheelsModMenuFor(mSMuscle, iSMuscle, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCMuscle, iCMuscle, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmOffroad, mSOffroad, mCOffroad, iSOffroad, iCOffroad)
        RefreshStockWheelsModMenuFor(mSOffroad, iSOffroad, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCOffroad, iCOffroad, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmSport, mSSport, mCSport, iSSport, iCSport)
        RefreshStockWheelsModMenuFor(mSSport, iSSport, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCSport, iCSport, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmSUV, mSSUV, mCSUV, iSSUV, iCSUV)
        RefreshStockWheelsModMenuFor(mSSUV, iSSUV, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCSUV, iCSUV, VehicleMod.FrontWheels)
        RefreshWheelRimMenu(gmTuner, mSTuner, mCTuner, iSTuner, iCTuner)
        RefreshStockWheelsModMenuFor(mSTuner, iSTuner, VehicleMod.FrontWheels)
        RefreshChromeWheelsModMenuFor(mCTuner, iCTuner, VehicleMod.FrontWheels)
        RefreshLowriderDLCWheelsModMenuFor(mBennysOriginals, iBennys, VehicleMod.FrontWheels)
        RefreshLowriderDLCWheelsModMenuFor(mBespoke, iBespoke, VehicleMod.FrontWheels)
        RefreshEnumModMenuFor(mRimColor, iRimColor, EnumTypes.VehicleColorRim)
        RefreshTyresMenu()
        RefreshRGBColorMenuFor(mTireSmoke, iTireSmoke, "Smoke")
        RefreshPlateMenu()
        RefreshModMenuFor(mPlateHolder, iPlateHolder, VehicleMod.PlateHolder)
        RefreshModMenuFor(mVanityPlates, iVanityPlates, VehicleMod.VanityPlates)
        RefreshEnumModMenuFor(mNumberPlate, iNumberPlate, EnumTypes.NumberPlateType)
        RefreshLightsMenu()
        RefreshModMenuForHeadlightsColor(mHeadlights, iHeadlights, VehicleToggleMod.XenonHeadlights)
        RefreshNeonKitsMenu()
        RefreshNeonMenu()
        RefreshRGBColorMenuFor(mNeonColor, iNeonColor, "Neon")
        RefreshResprayMenu()
        RefreshPrimaryColorMenu()
        RefreshColorMenuFor(mPrimaryChromeColor, iPrimaryChromeColor, ChromeColor, "Primary")
        RefreshColorMenuFor(mPrimaryClassicColor, iPrimaryClassicColor, ClassicColor, "Primary")
        RefreshColorMenuFor(mPrimaryMetallicColor, iPrimaryMetallicColor, ClassicColor, "Primary")
        RefreshColorMenuFor(mPrimaryMetalsColor, iPrimaryMetalsColor, MetalColor, "Primary")
        RefreshColorMenuFor(mPrimaryMatteColor, iPrimaryMatteColor, MatteColor, "Primary")
        RefreshColorMenuFor(mPrimaryPearlescentColor, iPrimaryPearlescentColor, PearlescentColor, "Pearlescent")
        RefreshSecondaryColorMenu()
        RefreshColorMenuFor(mSecondaryChromeColor, iSecondaryChromeColor, ChromeColor, "Secondary")
        RefreshColorMenuFor(mSecondaryClassicColor, iSecondaryClassicColor, ClassicColor, "Secondary")
        RefreshColorMenuFor(mSecondaryMetallicColor, iSecondaryMetallicColor, ClassicColor, "Secondary")
        RefreshColorMenuFor(mSecondaryMetalsColor, iSecondaryMetalsColor, MetalColor, "Secondary")
        RefreshColorMenuFor(mSecondaryMatteColor, iSecondaryMatteColor, MatteColor, "Secondary")
        RefreshModMenuFor(mExhaust, iExhaust, VehicleMod.Exhaust)
        RefreshModMenuFor(mFender, iFender, VehicleMod.Fender)
        RefreshModMenuFor(mRFender, iRFender, VehicleMod.RightFender)
        RefreshModMenuFor(mFrame, iFrame, VehicleMod.Frame)
        RefreshModMenuFor(mGrille, iGrille, VehicleMod.Grille)
        RefreshModMenuFor(mHood, iHood, VehicleMod.Hood)
        RefreshModMenuFor(mHorn, iHorn, VehicleMod.Horns)
        RefreshModMenuFor(mHydraulics, iHydraulics, VehicleMod.Hydraulics)
        RefreshModMenuFor(mLivery, iLivery, VehicleMod.Livery)
        RefreshModMenuForLivery2(mTornadoC, iTornadoC)
        RefreshModMenuFor(mPlaques, iPlaques, VehicleMod.Plaques)
        RefreshModMenuFor(mRoof, iRoof, VehicleMod.Roof)
        RefreshModMenuFor(mSpeakers, iSpeaker, VehicleMod.Speakers)
        RefreshModMenuFor(mSpoilers, iSpoilers, VehicleMod.Spoilers)
        RefreshModMenuFor(mTank, iTank, VehicleMod.Tank)
        RefreshModMenuFor(mTrunk, iTrunk, VehicleMod.Trunk)
        RefreshModMenuFor(mTurbo, iTurbo, VehicleToggleMod.Turbo)
        RefreshPerformanceMenuFor(mSuspension, iSuspension, VehicleMod.Suspension, "CMOD_SUS_")
        RefreshPerformanceMenuFor(mArmor, iArmor, VehicleMod.Armor, "CMOD_ARM_")
        RefreshPerformanceMenuFor(mBrakes, iBrakes, VehicleMod.Brakes, "CMOD_BRA_")
        RefreshPerformanceMenuFor(mTransmission, iTransmission, VehicleMod.Transmission, "CMOD_GBX_")
        RefreshEnumModMenuFor(mTint, iTint, EnumTypes.VehicleWindowTint)
        'Motorcycles
        RefreshModMenuFor(mShifter, iShifter, VehicleMod.Fender)
        RefreshModMenuFor(mFMudguard, iFMudguard, VehicleMod.FrontBumper)
        RefreshModMenuFor(mBSeat, iBSeat, VehicleMod.Hood)
        RefreshModMenuFor(mOilTank, iOilTank, VehicleMod.Grille)
        RefreshModMenuFor(mRMudguard, iRMudguard, VehicleMod.RearBumper)
        RefreshModMenuFor(mFuelTank, iFuelTank, VehicleMod.Roof)
        RefreshModMenuFor(mBeltDriveCovers, iBeltDriveCovers, VehicleMod.Spoilers)
        RefreshModMenuFor(mBEngineBlock, iBEngineBlock, VehicleMod.Frame)
        RefreshModMenuFor(mBAirFilter, iBAirFilter, VehicleMod.SideSkirt)
        RefreshModMenuFor(mBTank, iBTank, VehicleMod.Tank)
        RefreshMainMenu()
    End Sub

    Public Sub RefreshBodyworkArenaMenu()
        Try
            gmBodyworkArena.MenuItems.Clear()

            If veh.ClassType = VehicleClass.Motorcycles Then
                If veh.GetModCount(VehicleMod.Plaques) <> 0 Then
                    iPlaques = New UIMenuItem(LocalizedModTypeName(VehicleMod.Plaques), Game.GetGXTEntry("collision_di2ru")) 'Decoration
                    gmBodyworkArena.AddItem(iPlaques)
                    gmBodyworkArena.BindMenuToItem(mPlaques, iPlaques)
                End If
                If veh.GetModCount(VehicleMod.Frame) <> 0 Then
                    iFrame = New UIMenuItem(LocalizedModTypeName(VehicleMod.Frame), Game.GetGXTEntry("CMOD_ARMPL_D")) 'Armour plating
                    gmBodyworkArena.AddItem(iFrame)
                    gmBodyworkArena.BindMenuToItem(mFrame, iFrame)
                End If
                If veh.GetModCount(VehicleMod.Aerials) <> 0 Then
                    iAerials = New UIMenuItem(LocalizedModTypeName(VehicleMod.Aerials), Game.GetGXTEntry("collision_37l2i4l")) 'Spikes
                    gmBodyworkArena.AddItem(iAerials)
                    gmBodyworkArena.BindMenuToItem(mAerials, iAerials)
                End If
                If veh.GetModCount(VehicleMod.Trim) <> 0 Then
                    iTrim = New UIMenuItem(LocalizedModTypeName(VehicleMod.Trim), Game.GetGXTEntry("collision_8t77hko")) 'Blades
                    gmBodyworkArena.AddItem(iTrim)
                    gmBodyworkArena.BindMenuToItem(mTrim, iTrim)
                End If
                If veh.GetModCount(VehicleMod.VanityPlates) <> 0 Then
                    giVanityPlate = New UIMenuItem(LocalizedModTypeName(VehicleMod.VanityPlates), Game.GetGXTEntry("collision_7we93ne")) 'Rear Wibbles
                    gmBodyworkArena.AddItem(giVanityPlate)
                    gmBodyworkArena.BindMenuToItem(mVanityPlates, giVanityPlate)
                End If
            Else
                If veh.GetModCount(VehicleMod.Plaques) <> 0 Then
                    iPlaques = New UIMenuItem(LocalizedModTypeName(VehicleMod.Plaques), Game.GetGXTEntry("collision_di2ru")) 'Decoration
                    gmBodyworkArena.AddItem(iPlaques)
                    gmBodyworkArena.BindMenuToItem(mPlaques, iPlaques)
                End If
                If veh.GetModCount(VehicleMod.Frame) <> 0 Then
                    iFrame = New UIMenuItem(LocalizedModTypeName(VehicleMod.Frame), Game.GetGXTEntry("CMOD_ARMPL_D")) 'Armour plating
                    gmBodyworkArena.AddItem(iFrame)
                    gmBodyworkArena.BindMenuToItem(mFrame, iFrame)
                End If
                If veh.GetModCount(VehicleMod.Aerials) <> 0 Then
                    iAerials = New UIMenuItem(LocalizedModTypeName(VehicleMod.Aerials), Game.GetGXTEntry("collision_37l2i4l")) 'Spikes
                    gmBodyworkArena.AddItem(iAerials)
                    gmBodyworkArena.BindMenuToItem(mAerials, iAerials)
                End If
                If veh.GetModCount(VehicleMod.Trim) <> 0 Then
                    iTrim = New UIMenuItem(LocalizedModTypeName(VehicleMod.Trim), Game.GetGXTEntry("collision_8t77hko")) 'Blades
                    gmBodyworkArena.AddItem(iTrim)
                    gmBodyworkArena.BindMenuToItem(mTrim, iTrim)
                End If
                If veh.GetModCount(VehicleMod.VanityPlates) <> 0 Then
                    giVanityPlate = New UIMenuItem(LocalizedModTypeName(VehicleMod.VanityPlates), Game.GetGXTEntry("collision_7we93ne")) 'Rear Wibbles
                    gmBodyworkArena.AddItem(giVanityPlate)
                    gmBodyworkArena.BindMenuToItem(mVanityPlates, giVanityPlate)
                End If
                If veh.GetModCount(VehicleMod.Ornaments) <> 0 Then
                    giOrnaments = New UIMenuItem(LocalizedModTypeName(VehicleMod.Ornaments), Game.GetGXTEntry("CMOD_MOD_53_D")) 'Roll Cage
                    gmBodyworkArena.AddItem(giOrnaments)
                    gmBodyworkArena.BindMenuToItem(mOrnaments, giOrnaments)
                End If
            End If

            gmBodyworkArena.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshWeaponMenu()
        Try
            gmWeapon.MenuItems.Clear()

            If veh.ClassType = VehicleClass.Motorcycles Then
                If veh.GetModCount(VehicleMod.Tank) <> 0 Then
                    giTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Tank), Game.GetGXTEntry("collision_255bdwf")) 'Primary Weapons
                    gmWeapon.AddItem(giTank)
                    gmWeapon.BindMenuToItem(mTank, giTank)
                End If
            Else
                If veh.GetModCount(VehicleMod.ArchCover) <> 0 Then
                    giArchCover = New UIMenuItem(LocalizedModTypeName(VehicleMod.ArchCover), Game.GetGXTEntry("collision_835p5rm")) 'Ram Weapons
                    gmWeapon.AddItem(giArchCover)
                    gmWeapon.BindMenuToItem(mArchCover, giArchCover)
                End If
                If veh.GetModCount(VehicleMod.RightFender) <> 0 Then
                    iRFender = New UIMenuItem(LocalizedModTypeName(VehicleMod.RightFender), Game.GetGXTEntry("CMOD_PROMI_D")) 'Proximity Mine
                    gmWeapon.AddItem(iRFender)
                    gmWeapon.BindMenuToItem(mRFender, iRFender)
                End If
                If veh.GetModCount(VehicleMod.Tank) <> 0 Then
                    giTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Tank), Game.GetGXTEntry("collision_255bdwf")) 'Primary Weapons
                    gmWeapon.AddItem(giTank)
                    gmWeapon.BindMenuToItem(mTank, giTank)
                End If
                If veh.GetModCount(VehicleMod.Roof) <> 0 Then
                    giRoof = New UIMenuItem(LocalizedModTypeName(VehicleMod.Roof), Game.GetGXTEntry("CMOD_SEWEAP_D")) 'Secondary Weapons
                    gmWeapon.AddItem(giRoof)
                    gmWeapon.BindMenuToItem(mRoof, giRoof)
                End If
            End If

            gmWeapon.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshArenaWarMenu()
        Try
            mUpgradeAW.MenuItems.Clear()

            Select Case veh.Model
                Case "glendale"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("bruiser"))
                    With iUpgradeAWV
                        .SubString1 = "bruiser"
                        .SubString2 = "bruiser_apoc"
                        .SubInteger1 = 1609000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("bruiser2"))
                    With iUpgradeAWV
                        .SubString1 = "bruiser2"
                        .SubString2 = "bruiser_scifi"
                        .SubInteger1 = 1609000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("bruiser3"))
                    With iUpgradeAWV
                        .SubString1 = "bruiser3"
                        .SubString2 = "bruiser_cons"
                        .SubInteger1 = 1609000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "gargoyle"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("deathbike"))
                    With iUpgradeAWV
                        .SubString1 = "deathbike"
                        .SubString2 = "deathbike_apoc"
                        .SubInteger1 = 1269000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("deathbike2"))
                    With iUpgradeAWV
                        .SubString1 = "deathbike2"
                        .SubString2 = "deathbike_scifi"
                        .SubInteger1 = 1269000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("deathbike3"))
                    With iUpgradeAWV
                        .SubString1 = "deathbike3"
                        .SubString2 = "deathbike_cons"
                        .SubInteger1 = 1269000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "dominator", "dominator2"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("dominator4"))
                    With iUpgradeAWV
                        .SubString1 = "dominator4"
                        .SubString2 = "dominator_apoc"
                        .SubInteger1 = 1132000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("dominator5"))
                    With iUpgradeAWV
                        .SubString1 = "dominator5"
                        .SubString2 = "dominator_scifi"
                        .SubInteger1 = 1132000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("dominator6"))
                    With iUpgradeAWV
                        .SubString1 = "dominator6"
                        .SubString2 = "dominator_cons"
                        .SubInteger1 = 1132000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "impaler"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("impaler2"))
                    With iUpgradeAWV
                        .SubString1 = "impaler2"
                        .SubString2 = "impaler_apoc"
                        .SubInteger1 = 1209500
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("impaler3"))
                    With iUpgradeAWV
                        .SubString1 = "impaler3"
                        .SubString2 = "impaler_scifi"
                        .SubInteger1 = 1209500
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("impaler4"))
                    With iUpgradeAWV
                        .SubString1 = "impaler4"
                        .SubString2 = "impaler_cons"
                        .SubInteger1 = 1209500
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "issi3"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("issi4"))
                    With iUpgradeAWV
                        .SubString1 = "issi4"
                        .SubString2 = "issi_apoc"
                        .SubInteger1 = 1089000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("issi5"))
                    With iUpgradeAWV
                        .SubString1 = "issi5"
                        .SubString2 = "issi_scifi"
                        .SubInteger1 = 1089000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("issi6"))
                    With iUpgradeAWV
                        .SubString1 = "issi6"
                        .SubString2 = "issi_cons"
                        .SubInteger1 = 1089000
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "ratloader", "ratloader2"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("monster3"))
                    With iUpgradeAWV
                        .SubString1 = "monster3"
                        .SubString2 = "sasquatch_apoc"
                        .SubInteger1 = 1530875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("monster4"))
                    With iUpgradeAWV
                        .SubString1 = "monster4"
                        .SubString2 = "sasquatch_scifi"
                        .SubInteger1 = 1530875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("monster5"))
                    With iUpgradeAWV
                        .SubString1 = "monster5"
                        .SubString2 = "sasquatch_cons"
                        .SubInteger1 = 1530875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                Case "slamvan", "slamvan2", "slamvan3"
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("slamvan4"))
                    With iUpgradeAWV
                        .SubString1 = "slamvan4"
                        .SubString2 = "slamvan_apoc"
                        .SubInteger1 = 1321875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("slamvan5"))
                    With iUpgradeAWV
                        .SubString1 = "slamvan5"
                        .SubString2 = "slamvan_scifi"
                        .SubInteger1 = 1321875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
                    iUpgradeAWV = New UIMenuItem(Game.GetGXTEntry("slamvan6"))
                    With iUpgradeAWV
                        .SubString1 = "slamvan6"
                        .SubString2 = "slamvan_cons"
                        .SubInteger1 = 1321875
                        Dim price As String = "$" & .SubInteger1
                        .SetRightLabel(price)
                    End With
                    mUpgradeAW.AddItem(iUpgradeAWV)
            End Select

            mUpgradeAW.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshBodyworkMenu()
        Try
            gmBodywork.MenuItems.Clear()

            If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                If veh.GetModCount(VehicleMod.Fender) <> 0 Then
                    giShifter = New UIMenuItem(LocalizedModTypeName(VehicleMod.Fender), Game.GetGXTEntry("CMOD_MOD_SHI_D"))
                    gmBodywork.AddItem(giShifter)
                    gmBodywork.BindMenuToItem(mShifter, giShifter)
                End If
                If veh.GetModCount(VehicleMod.FrontBumper) <> 0 Then
                    giFMudguard = New UIMenuItem(LocalizedModTypeName(VehicleMod.FrontBumper), Game.GetGXTEntry("CMOD_MOD_43_D"))
                    gmBodywork.AddItem(giFMudguard)
                    gmBodywork.BindMenuToItem(mFMudguard, giFMudguard)
                End If
                If veh.GetModCount(VehicleMod.Hood) <> 0 Then
                    iBSeat = New UIMenuItem(LocalizedModTypeName(VehicleMod.Hood), Game.GetGXTEntry("CMOD_MOD_44_D"))
                    gmBodywork.AddItem(iBSeat)
                    gmBodywork.BindMenuToItem(mBSeat, iBSeat)
                End If
                If veh.GetModCount(VehicleMod.Grille) <> 0 Then
                    giOilTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Grille), Game.GetGXTEntry("CMOD_MOD_OT_D"))
                    gmBodywork.AddItem(giOilTank)
                    gmBodywork.BindMenuToItem(mOilTank, giOilTank)
                End If
                If veh.GetModCount(VehicleMod.RearBumper) <> 0 Then
                    giRMudguard = New UIMenuItem(LocalizedModTypeName(VehicleMod.RearBumper), Game.GetGXTEntry("CMOD_MOD_43_D"))
                    gmBodywork.AddItem(giRMudguard)
                    gmBodywork.BindMenuToItem(mRMudguard, giRMudguard)
                End If
                If veh.GetModCount(VehicleMod.Roof) <> 0 Then
                    giFuelTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Roof), Game.GetGXTEntry("CMOD_MOD_FUT_D"))
                    gmBodywork.AddItem(giFuelTank)
                    gmBodywork.BindMenuToItem(mFuelTank, giFuelTank)
                End If
                If veh.GetModCount(VehicleMod.Spoilers) <> 0 Then
                    giBeltDriveCovers = New UIMenuItem(LocalizedModTypeName(VehicleMod.Spoilers), Game.GetGXTEntry("CMOD_MOD_BEC_D"))
                    gmBodywork.AddItem(giBeltDriveCovers)
                    gmBodywork.BindMenuToItem(mBeltDriveCovers, giBeltDriveCovers)
                End If
                If veh.GetModCount(VehicleMod.RightFender) <> 0 Then
                    iRFender = New UIMenuItem(LocalizedModTypeName(VehicleMod.RightFender), Game.GetGXTEntry("CMOD_MOD_41_D"))
                    gmBodywork.AddItem(iRFender)
                    gmBodywork.BindMenuToItem(mRFender, iRFender)
                End If
                If veh.GetModCount(VehicleMod.Tank) <> 0 Then
                    giBTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Tank), Game.GetGXTEntry("CMOD_MOD_45_D"))
                    gmBodywork.AddItem(giBTank)
                    gmBodywork.BindMenuToItem(mBTank, giBTank)
                End If
            Else
                If veh.GetModCount(VehicleMod.Aerials) <> 0 Then
                    iAerials = New UIMenuItem(LocalizedModTypeName(VehicleMod.Aerials), Game.GetGXTEntry("SMOD_CHASS_6"))
                    gmBodywork.AddItem(iAerials)
                    gmBodywork.BindMenuToItem(mAerials, iAerials)
                End If
                If veh.GetModCount(VehicleMod.Trim) <> 0 Then
                    iTrim = New UIMenuItem(LocalizedModTypeName(VehicleMod.Trim), Game.GetGXTEntry("SMOD_CHASS_1b"))
                    gmBodywork.AddItem(iTrim)
                    gmBodywork.BindMenuToItem(mTrim, iTrim)
                End If
                If veh.GetModCount(VehicleMod.Windows) <> 0 Then
                    iWindows = New UIMenuItem(LocalizedModTypeName(VehicleMod.Windows), Game.GetGXTEntry("SMOD_CHASS_5"))
                    gmBodywork.AddItem(iWindows)
                    gmBodywork.BindMenuToItem(mWindow, iWindows)
                End If
                If veh.GetModCount(VehicleMod.ArchCover) <> 0 Then
                    iArchCover = New UIMenuItem(LocalizedModTypeName(VehicleMod.ArchCover), Game.GetGXTEntry("SMOD_CHASS_1c")) 'Arch Covers
                    gmBodywork.AddItem(iArchCover)
                    gmBodywork.BindMenuToItem(mArchCover, iArchCover)
                End If
            End If

            gmBodywork.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshModMenuForLivery2(ByRef menu As UIMenu, ByRef item As UIMenuItem)
        Try
            menu.MenuItems.Clear()
            For i As Integer = 0 To veh.Livery2Count - 1
                item = New UIMenuItem(LocalizedT5RoofName(i))
                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetLivery2 = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 200 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 200 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod)
        Try
            menu.MenuItems.Clear()
            For i As Integer = -1 To veh.GetModCount(vehmod) - 1
                item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetMod(vehmod) = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 200 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 200 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleToggleMod)
        Try
            menu.MenuItems.Clear()

            item = New UIMenuItem(LocalizedModTypeName(vehmod, True))
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                .SubInteger1 = 0
                If Not veh.IsToggleModOn(vehmod) Then item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            End With
            menu.AddItem(item)
            item = New UIMenuItem(LocalizedModTypeName(vehmod))
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                .SubInteger1 = 1
                If veh.IsToggleModOn(vehmod) Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 1000
                    item.SetRightLabel(price)
                    .SubInteger2 = 1000
                End If
            End With
            menu.AddItem(item)

            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshModMenuForHeadlightsColor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleToggleMod)
        Try
            menu.MenuItems.Clear()

            item = New UIMenuItem(Game.GetGXTEntry("CMOD_LGT_0"))
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_LGT_0")
                .SubInteger1 = 0
                .SubInteger3 = 255
                If Not veh.IsToggleModOn(vehmod) Then item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
            End With
            menu.AddItem(item)
            item = New UIMenuItem(LocalizedModTypeName(vehmod))
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                .SubInteger1 = 1
                .SubInteger3 = 255
                If veh.IsToggleModOn(vehmod) Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 1000
                    item.SetRightLabel(price)
                    .SubInteger2 = 1000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_9vtlzex")) 'White
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_9vtlzex")
                .SubInteger1 = 1
                .SubInteger3 = 0
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_9vtlzey")) 'Blue
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_9vtlzey")
                .SubInteger1 = 1
                .SubInteger3 = 1
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_9vtlzez")) 'Electric Blue
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_9vtlzez")
                .SubInteger1 = 1
                .SubInteger3 = 2
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_8gbxm1p")) 'Mint Green
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_8gbxm1p")
                .SubInteger1 = 1
                .SubInteger3 = 3
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_8gbxm1q")) 'Lime Green
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_8gbxm1q")
                .SubInteger1 = 1
                .SubInteger3 = 4
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_8gbxm1r")) 'Yellow
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_8gbxm1r")
                .SubInteger1 = 1
                .SubInteger3 = 5
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_8gbxm1s")) 'Golden Shower
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_8gbxm1s")
                .SubInteger1 = 1
                .SubInteger3 = 6
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_8gbxm1t")) 'Orange
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_7jh67le")
                .SubInteger1 = 1
                .SubInteger3 = 7
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_7jh67le")) 'Red
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_8gbxm1t")
                .SubInteger1 = 1
                .SubInteger3 = 8
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_7jh67lg")) 'Pony Pink
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_7jh67lg")
                .SubInteger1 = 1
                .SubInteger3 = 9
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_7jh67lf")) 'Hot Pink
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_7jh67lf")
                .SubInteger1 = 1
                .SubInteger3 = 10
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_7jh67lh")) 'Blacklight
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_7jh67lh")
                .SubInteger1 = 1
                .SubInteger3 = 11
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            item = New UIMenuItem(Game.GetGXTEntry("collision_7jh67li")) 'Purple
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_7jh67li")
                .SubInteger1 = 1
                .SubInteger3 = 12
                If veh.GetXenonHeadlightsColor = 0 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim price As String = "$" & 3000
                    item.SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            menu.AddItem(item)
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshEngineMenu()
        Try
            gmEngine.MenuItems.Clear()

            If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                If veh.GetModCount(VehicleMod.Frame) <> 0 Then
                    giBEngineBlock = New UIMenuItem(LocalizedModTypeName(VehicleMod.Frame), Game.GetGXTEntry("SMOD_ENGINE_1"))
                    gmEngine.AddItem(giBEngineBlock)
                    gmEngine.BindMenuToItem(mBEngineBlock, giBEngineBlock)
                End If
                If veh.GetModCount(VehicleMod.Engine) <> 0 Then
                    iEngine = New UIMenuItem(LocalizedModTypeName(VehicleMod.Engine), Game.GetGXTEntry("SMOD_ENGINE_4"))
                    gmEngine.AddItem(iEngine)
                    gmEngine.BindMenuToItem(mEngine, iEngine)
                End If
                If veh.GetModCount(VehicleMod.SideSkirt) <> 0 Then
                    giBAirFilter = New UIMenuItem(LocalizedModTypeName(VehicleMod.SideSkirt), Game.GetGXTEntry("CMOD_SMOD_2_D"))
                    gmEngine.AddItem(giBAirFilter)
                    gmEngine.BindMenuToItem(mBAirFilter, giBAirFilter)
                End If
                If veh.CanInstallNitroMod Then
                    iNitro = New UIMenuItem(Game.GetGXTEntry("CMM_MOD_NJBOS"), Game.GetGXTEntry("SMOD_ENGINE_2"))
                    gmEngine.AddItem(iNitro)
                    gmEngine.BindMenuToItem(mNitro, iNitro)
                End If
            Else
                If veh.GetModCount(VehicleMod.Engine) <> 0 Then
                    iEngine = New UIMenuItem(LocalizedModTypeName(VehicleMod.Engine), Game.GetGXTEntry("SMOD_ENGINE_4"))
                    gmEngine.AddItem(iEngine)
                    gmEngine.BindMenuToItem(mEngine, iEngine)
                End If
                If veh.GetModCount(VehicleMod.EngineBlock) <> 0 Then
                    iEngineBlock = New UIMenuItem(LocalizedModTypeName(VehicleMod.EngineBlock), Game.GetGXTEntry("SMOD_ENGINE_1"))
                    gmEngine.AddItem(iEngineBlock)
                    gmEngine.BindMenuToItem(mEngineBlock, iEngineBlock)
                End If
                If veh.CanInstallNitroMod Then
                    iNitro = New UIMenuItem(Game.GetGXTEntry("CMM_MOD_NJBOS"), Game.GetGXTEntry("SMOD_ENGINE_2"))
                    gmEngine.AddItem(iNitro)
                    gmEngine.BindMenuToItem(mNitro, iNitro)
                End If
                If Not arenavehicle.Contains(veh.Model) Then
                    If veh.GetModCount(VehicleMod.AirFilter) <> 0 Then
                        giAirfilter = New UIMenuItem(LocalizedModTypeName(VehicleMod.AirFilter), Game.GetGXTEntry("SMOD_ENGINE_2"))
                        gmEngine.AddItem(giAirfilter)
                        gmEngine.BindMenuToItem(mAirFilter, giAirfilter)
                    End If
                    If veh.GetModCount(VehicleMod.Struts) <> 0 Then
                        giStruts = New UIMenuItem(LocalizedModTypeName(VehicleMod.Struts), Game.GetGXTEntry("SMOD_ENGINE_3b"))
                        gmEngine.AddItem(giStruts)
                        gmEngine.BindMenuToItem(mStruts, giStruts)
                    End If
                End If
            End If

            gmEngine.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshPerformanceMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod, ByRef gxt As String)
        Try
            menu.MenuItems.Clear()

            For i As Integer = -1 To veh.GetModCount(vehmod) - 1
                Select Case vehmod
                    Case VehicleMod.Engine
                        item = New UIMenuItem(Game.GetGXTEntry(gxt & i + 2))
                    Case Else
                        item = New UIMenuItem(Game.GetGXTEntry(gxt & i + 1))
                End Select

                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetMod(vehmod) = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 2000 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 2000 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshNitroMenu()
        Try
            mNitro.MenuItems.Clear()

            iNitro = New UIMenuItem(Game.GetGXTEntry("CMOD_ARM_0"))
            With iNitro
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                .SubInteger1 = CInt(False)
                If Not veh.GetBool(nitroMod) Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
            End With
            mNitro.AddItem(iNitro)
            iNitro = New UIMenuItem(Game.GetGXTEntry("collision_57fffph")) 'Upgrade 100%
            With iNitro
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("collision_57fffph")
                .SubInteger1 = CInt(True)
                If veh.GetBool(nitroMod) Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 30000
                    Dim price As String = $"${value}"
                    .SetRightLabel(price)
                    .SubInteger2 = 30000
                End If
            End With
            mNitro.AddItem(iNitro)

            mNitro.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshInteriorMenu()
        Try
            gmInterior.MenuItems.Clear()
            If veh.GetModCount(VehicleMod.ColumnShifterLevers) <> 0 Then
                iColumnShifterLevers = New UIMenuItem(LocalizedModTypeName(VehicleMod.ColumnShifterLevers), Game.GetGXTEntry("SMOD_IN_KNOB"))
                gmInterior.AddItem(iColumnShifterLevers)
                gmInterior.BindMenuToItem(mColumnShifterLevers, iColumnShifterLevers)
            End If
            If veh.GetModCount(VehicleMod.Dashboard) <> 0 Then
                iDashboard = New UIMenuItem(LocalizedModTypeName(VehicleMod.Dashboard), Game.GetGXTEntry("SMOD_IN_2"))
                gmInterior.AddItem(iDashboard)
                gmInterior.BindMenuToItem(mDashboard, iDashboard)
            End If
            If veh.GetModCount(VehicleMod.DialDesign) <> 0 Then
                iDialDesign = New UIMenuItem(LocalizedModTypeName(VehicleMod.DialDesign), Game.GetGXTEntry("SMOD_IN_4"))
                gmInterior.AddItem(iDialDesign)
                gmInterior.BindMenuToItem(mDialDesign, iDialDesign)
            End If
            If Not arenavehicle.Contains(veh.Model) Then
                If veh.GetModCount(VehicleMod.Ornaments) <> 0 Then
                    iOrnaments = New UIMenuItem(LocalizedModTypeName(VehicleMod.Ornaments), Game.GetGXTEntry("CMOD_MOD_64_D"))
                    gmInterior.AddItem(iOrnaments)
                    gmInterior.BindMenuToItem(mOrnaments, iOrnaments)
                End If
            End If
            If veh.GetModCount(VehicleMod.Seats) <> 0 Then
                iSeats = New UIMenuItem(LocalizedModTypeName(VehicleMod.Seats), Game.GetGXTEntry("SMOD_IN_SEAT"))
                gmInterior.AddItem(iSeats)
                gmInterior.BindMenuToItem(mSeats, iSeats)
            End If
            If veh.GetModCount(VehicleMod.SteeringWheels) <> 0 Then
                iSteeringWheels = New UIMenuItem(LocalizedModTypeName(VehicleMod.SteeringWheels), Game.GetGXTEntry("SMOD_IN_STEER"))
                gmInterior.AddItem(iSteeringWheels)
                gmInterior.BindMenuToItem(mSteeringWheels, iSteeringWheels)
            End If
            If veh.GetModCount(VehicleMod.TrimDesign) <> 0 Then
                iTrimDesign = New UIMenuItem(LocalizedModTypeName(VehicleMod.TrimDesign), Game.GetGXTEntry("SMOD_IN_3"))
                gmInterior.AddItem(iTrimDesign)
                gmInterior.BindMenuToItem(mTrimDesign, iTrimDesign)
            End If
            If veh.GetModCount(VehicleMod.DoorSpeakers) <> 0 Then
                giDoor = New UIMenuItem(LocalizedModTypeName(VehicleMod.DoorSpeakers), Game.GetGXTEntry("SMOD_IN_5b"))
                gmInterior.AddItem(giDoor)
                gmInterior.BindMenuToItem(mDoor, giDoor)
            End If
            If veh.GetModCount(VehicleMod.Speakers) <> 0 Then
                iSpeaker = New UIMenuItem(LocalizedModTypeName(VehicleMod.Speakers), Game.GetGXTEntry("CMOD_MOD_23_D"))
                gmInterior.AddItem(iSpeaker)
                gmInterior.BindMenuToItem(mSpeakers, iSpeaker)
            End If
            If bennysvehicle.Contains(veh.Model) Then
                iDashboardColor = New UIMenuItem(LocalizedModGroupName(GroupName.LightColor), Game.GetGXTEntry("SMOD_LIGHT_COLb"))
                gmInterior.AddItem(iDashboardColor)
                gmInterior.BindMenuToItem(mLightsColor, iDashboardColor)
                iTrimColor = New UIMenuItem(LocalizedModGroupName(GroupName.TrimColor), Game.GetGXTEntry("CMOD_MOD_6_D")) 'trim color
                gmInterior.AddItem(iTrimColor)
                gmInterior.BindMenuToItem(mTrimColor, iTrimColor)
            End If
            gmInterior.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshEnumModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef enumType As EnumTypes)
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
                            If veh.NumberPlateType = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 200
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 200
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleWindowTint
                    enumArray = System.Enum.GetValues(GetType(VehicleWindowTint))
                    For Each enumItem As VehicleWindowTint In enumArray
                        item = New UIMenuItem(LocalizedWindowsTint(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.WindowTint = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorPrimary
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.PrimaryColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorSecondary
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.SecondaryColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.vehicleColorPearlescent
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.PearlescentColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorTrim
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.TrimColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorDashboard
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.DashboardColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
                Case EnumTypes.VehicleColorRim
                    enumArray = System.Enum.GetValues(GetType(VehicleColor))
                    For Each enumItem As VehicleColor In enumArray
                        item = New UIMenuItem(GetLocalizedColorName(enumItem))
                        With item
                            .SubInteger1 = enumItem
                            If veh.RimColor = enumItem Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 2000
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 2000
                            End If
                        End With
                        menu.AddItem(item)
                    Next
            End Select
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshBumperMenu()
        Try
            gmBumper.MenuItems.Clear()
            If veh.GetModCount(VehicleMod.FrontBumper) <> 0 Then
                giFBumper = New UIMenuItem(LocalizedModTypeName(VehicleMod.FrontBumper), Game.GetGXTEntry("CMOD_MOD_71_D"))
                gmBumper.AddItem(giFBumper)
                gmBumper.BindMenuToItem(mFBumper, giFBumper)
            End If
            If veh.GetModCount(VehicleMod.SideSkirt) <> 0 Then
                giSSkirt = New UIMenuItem(LocalizedModTypeName(VehicleMod.SideSkirt), Game.GetGXTEntry("CMOD_MOD_21_D"))
                gmBumper.AddItem(giSSkirt)
                gmBumper.BindMenuToItem(mSSkirt, giSSkirt)
            End If
            If veh.GetModCount(VehicleMod.RearBumper) <> 0 Then
                giRBumper = New UIMenuItem(LocalizedModTypeName(VehicleMod.RearBumper), Game.GetGXTEntry("CMOD_MOD_71_D"))
                gmBumper.AddItem(giRBumper)
                gmBumper.BindMenuToItem(mRBumper, giRBumper)
            End If
            gmBumper.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshWheelsMenu()
        Try
            gmWheels.MenuItems.Clear()
            giWheelType = New UIMenuItem(LocalizedModGroupName(GroupName.WheelType), Game.GetGXTEntry("CMOD_MOD_28_D")) 'Wheel Type
            gmWheels.AddItem(giWheelType)
            gmWheels.BindMenuToItem(gmWheelType, giWheelType)
            iRimColor = New UIMenuItem(LocalizedModGroupName(GroupName.WheelColor), Game.GetGXTEntry("CMOD_MOD_59_D"))
            gmWheels.AddItem(iRimColor)
            gmWheels.BindMenuToItem(mRimColor, iRimColor)
            giTires = New UIMenuItem(LocalizedModGroupName(GroupName.Tires), Game.GetGXTEntry("CMOD_IE_25_D"))
            gmWheels.AddItem(giTires)
            gmWheels.BindMenuToItem(mTires, giTires)
            iTireSmoke = New UIMenuItem(LocalizedModTypeName(VehicleToggleMod.TireSmoke), Game.GetGXTEntry("CMOD_IE_25_D"))
            gmWheels.AddItem(iTireSmoke)
            gmWheels.BindMenuToItem(mTireSmoke, iTireSmoke)
            iBPTires = New UIMenuItem(Game.GetGXTEntry("CMOD_GLD2_1"))
            With iBPTires
                If Not veh.CanTiresBurst Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 4000
                    Dim price As String = $"${value}"
                    .SetRightLabel(price)
                    .SubInteger2 = 4000
                End If
            End With
            gmWheels.AddItem(iBPTires)
            gmWheels.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshWheelTypeMenu()
        Try
            gmWheelType.MenuItems.Clear()

            Select Case veh.ClassType
                Case VehicleClass.Motorcycles, VehicleClass.Cycles
                    giBikeWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.BikeWheels))
                    gmWheelType.AddItem(giBikeWheels)
                    gmWheelType.BindMenuToItem(gmBikeWheels, giBikeWheels)
                Case Else
                    giHighEndWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.HighEnd))
                    gmWheelType.AddItem(giHighEndWheels)
                    gmWheelType.BindMenuToItem(gmHighEnd, giHighEndWheels)
                    giLowriderWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.Lowrider))
                    gmWheelType.AddItem(giLowriderWheels)
                    gmWheelType.BindMenuToItem(gmLowrider, giLowriderWheels)
                    giMuscleWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.Muscle))
                    gmWheelType.AddItem(giMuscleWheels)
                    gmWheelType.BindMenuToItem(gmMuscle, giMuscleWheels)
                    giOffroadWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.Offroad))
                    gmWheelType.AddItem(giOffroadWheels)
                    gmWheelType.BindMenuToItem(gmOffroad, giOffroadWheels)
                    giSportWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.Sport))
                    gmWheelType.AddItem(giSportWheels)
                    gmWheelType.BindMenuToItem(gmSport, giSportWheels)
                    giSUVWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.SUV))
                    gmWheelType.AddItem(giSUVWheels)
                    gmWheelType.BindMenuToItem(gmSUV, giSUVWheels)
                    giTunerWheels = New UIMenuItem(GetLocalizedWheelTypeName(VehicleWheelType.Tuner))
                    gmWheelType.AddItem(giTunerWheels)
                    gmWheelType.BindMenuToItem(gmTuner, giTunerWheels)
                    giBennysWheels = New UIMenuItem(GetLocalizedWheelTypeName(8)) 'Benny's Original
                    gmWheelType.AddItem(giBennysWheels)
                    gmWheelType.BindMenuToItem(mBennysOriginals, giBennysWheels)
                    giBespokeWheels = New UIMenuItem(GetLocalizedWheelTypeName(9)) 'Benny's Bespoke
                    gmWheelType.AddItem(giBespokeWheels)
                    gmWheelType.BindMenuToItem(mBespoke, giBespokeWheels)
            End Select

            gmWheelType.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshWheelRimMenu(ByRef menu As UIMenu, ByRef bindStock As UIMenu, ByRef bindChrome As UIMenu, ByRef itemStock As UIMenuItem, ByRef itemChrome As UIMenuItem)
        Try
            menu.MenuItems.Clear()
            itemStock = New UIMenuItem(Game.GetGXTEntry("CMOD_WHE4_0")) 'Stock Rims
            menu.AddItem(itemStock)
            menu.BindMenuToItem(bindStock, itemStock)
            itemChrome = New UIMenuItem(Game.GetGXTEntry("CMOD_WHE4_1")) 'Stock Rims
            menu.AddItem(itemChrome)
            menu.BindMenuToItem(bindChrome, itemChrome)
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshStockWheelsModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod)
        Try
            menu.MenuItems.Clear()
            Dim count As Integer = veh.GetModCount(vehmod)
            Dim half As Integer = count / 2

            For i As Integer = -1 To half - 1
                item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetMod(vehmod) = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 200 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 200 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshChromeWheelsModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod)
        Try
            menu.MenuItems.Clear()
            Dim count As Integer = veh.GetModCount(vehmod)
            Dim half As Integer = count / 2

            item = New UIMenuItem(GetLocalizedModName(-1, veh.GetModCount(vehmod), vehmod))
            With item
                If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                .SubInteger1 = -1
                If veh.GetMod(vehmod) = -1 Then
                    item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 200
                    Dim price As String = "$" & value
                    item.SetRightLabel(price)
                    .SubInteger2 = 200
                End If
            End With
            menu.AddItem(item)

            For i As Integer = half To veh.GetModCount(vehmod) - 1
                item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetMod(vehmod) = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 200 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 200 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshLowriderDLCWheelsModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod)
        Try
            menu.MenuItems.Clear()
            Dim count As Integer = veh.GetModCount(vehmod)
            Dim oneOver6 As Integer = count / 7

            For i As Integer = -1 To oneOver6 - 1
                item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                With item
                    If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                    .SubInteger1 = i
                    If veh.GetMod(vehmod) = i Then
                        item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        If Not i = -1 Then
                            Dim ii = i + 1
                            Dim value As Integer = 200 * ii
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 200 * ii
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshBikeWheelsModMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef vehmod As VehicleMod, ByRef chromeWheels As Boolean)
        Try
            menu.MenuItems.Clear()
            Dim count As Integer = veh.GetModCount(vehmod)
            Dim standard As List(Of Integer) = New List(Of Integer) From {-1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48}
            Dim chrome As List(Of Integer) = New List(Of Integer) From {-1, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71}

            If chromeWheels = False Then 'Standard
                For Each i As Integer In standard
                    item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                    With item
                        If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                        .SubInteger1 = i
                        If veh.GetMod(vehmod) = i Then
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        Else
                            If Not i = -1 Then
                                Dim ii = i + 1
                                Dim value As Integer = 200 * ii
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 200 * ii
                            End If
                        End If
                    End With
                    menu.AddItem(item)
                Next
            ElseIf chromeWheels = True Then 'Chrome
                For Each i As Integer In chrome
                    item = New UIMenuItem(GetLocalizedModName(i, veh.GetModCount(vehmod), vehmod))
                    With item
                        If .Text = "NULL" Then .Text = Game.GetGXTEntry("CMOD_ARM_0")
                        .SubInteger1 = i
                        If veh.GetMod(vehmod) = i Then
                            item.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        Else
                            If Not i = -1 Then
                                Dim ii = i + 1
                                Dim value As Integer = 200 * ii
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger2 = 200 * ii
                            End If
                        End If
                    End With
                    menu.AddItem(item)
                Next
            End If

            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshTyresMenu()
        Try
            mTires.MenuItems.Clear()

            If veh.GetMod(VehicleMod.FrontWheels) = -1 Then
                iTires = New UIMenuItem(Game.GetGXTEntry("CMOD_TYR_0"))
                With iTires
                    .SubInteger1 = 1
                    If Not IsCustomWheels() Then
                        .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    Else
                        Dim value As Integer = 100
                        Dim price As String = "$" & value
                        .SetRightLabel(price)
                        .SubInteger2 = 100
                    End If
                End With
                mTires.AddItem(iTires)
            Else
                Select Case veh.WheelType
                    Case 8, 9
                        Dim whe As Integer = GetBennysOriginalRim(veh.GetMod(VehicleMod.FrontWheels))
                        Dim count As Integer = veh.GetModCount(VehicleMod.FrontWheels)
                        Dim oneOver6 As Integer = count / 7
                        Dim thirtyOne As Integer = oneOver6 '31
                        iTires = New UIMenuItem(Game.GetGXTEntry("CMOD_TYR_0"))
                        With iTires
                            Dim newid As Integer = whe
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 100
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 100
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("collision_v925jg")) 'White Lines
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne) ' + 1
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 200
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 200
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("collision_v925jh")) 'Classic White Wall
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne * 2) ' + 2
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 300
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 300
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("collision_v925ji")) 'Retro White Wall
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne * 3) ' + 3
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 400
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 400
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("collision_v925jj")) 'Red Line
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne * 4) ' + 4
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim price As String = "$" & 500
                                .SetRightLabel(price)
                                .SubInteger2 = 500
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("collision_v925jk")) 'Blue Line
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne * 5) ' + 5
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 600
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 600
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("CMOD_TYR_1"))
                        With iTires
                            Dim newid As Integer = (whe + thirtyOne * 6) ' + 6
                            .SubInteger1 = newid
                            If veh.GetMod(VehicleMod.FrontWheels) = newid Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 700
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 700
                            End If
                        End With
                        mTires.AddItem(iTires)
                    Case Else
                        iTires = New UIMenuItem(Game.GetGXTEntry("CMOD_TYR_0"))
                        With iTires
                            .SubInteger1 = 1
                            If Not IsCustomWheels() Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 100
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 100
                            End If
                        End With
                        mTires.AddItem(iTires)
                        iTires = New UIMenuItem(Game.GetGXTEntry("CMOD_TYR_1"))
                        With iTires
                            .SubInteger1 = 7
                            If IsCustomWheels() Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 700
                                Dim price As String = "$" & value
                                .SetRightLabel(price)
                                .SubInteger2 = 700
                            End If
                        End With
                        mTires.AddItem(iTires)
                End Select
            End If
            mTires.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshRGBColorMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, neonsmoke As String)
        Try
            menu.MenuItems.Clear()
            Dim removeList As New List(Of String) From {"R", "G", "B", "A", "IsKnownColor", "IsEmpty", "IsNamedColor", "IsSystemColor", "Name", "Transparent"}
            For Each col As Reflection.PropertyInfo In GetType(Drawing.Color).GetProperties()
                If Not removeList.Contains(col.Name) Then
                    item = New UIMenuItem(Trim(RegularExpressions.Regex.Replace(col.Name, "[A-Z]", " ${0}")))
                    With item
                        .SubInteger1 = Drawing.Color.FromName(col.Name).R
                        .SubInteger2 = Drawing.Color.FromName(col.Name).G
                        .SubInteger3 = Drawing.Color.FromName(col.Name).B
                        If neonsmoke = "Neon" Then
                            If veh.NeonLightsColor = Drawing.Color.FromName(col.Name) Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 200
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger4 = 200
                            End If
                        ElseIf neonsmoke = "Smoke" Then
                            If veh.TireSmokeColor = Drawing.Color.FromName(col.Name) Then
                                .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            Else
                                Dim value As Integer = 200
                                Dim price As String = "$" & value
                                item.SetRightLabel(price)
                                .SubInteger4 = 200
                            End If
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

    Public Sub RefreshPlateMenu()
        Try
            gmPlate.MenuItems.Clear()
            If veh.GetModCount(VehicleMod.PlateHolder) <> 0 Then
                giPlateHolder = New UIMenuItem(LocalizedModTypeName(VehicleMod.PlateHolder), Game.GetGXTEntry("CMOD_MOD_49_D"))
                gmPlate.AddItem(giPlateHolder)
                gmPlate.BindMenuToItem(mPlateHolder, giPlateHolder)
            End If
            If Not arenavehicle.Contains(veh.Model) Then
                If veh.GetModCount(VehicleMod.VanityPlates) <> 0 Then
                    giVanityPlate = New UIMenuItem(LocalizedModTypeName(VehicleMod.VanityPlates), Game.GetGXTEntry("CMOD_SMOD_4_D"))
                    gmPlate.AddItem(giVanityPlate)
                    gmPlate.BindMenuToItem(mVanityPlates, giVanityPlate)
                End If
            End If
            giNumberPlate = New UIMenuItem(LocalizedModGroupName(GroupName.License), Game.GetGXTEntry("CMOD_MOD_18_D")) 'Number Plate
            gmPlate.AddItem(giNumberPlate)
            gmPlate.BindMenuToItem(mNumberPlate, giNumberPlate)
            gmPlate.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshLightsMenu()
        Try
            gmLights.MenuItems.Clear()
            iHeadlights = New UIMenuItem(LocalizedModGroupName(GroupName.Headlights), Game.GetGXTEntry("CMOD_MOD_47_D"))
            gmLights.AddItem(iHeadlights)
            gmLights.BindMenuToItem(mHeadlights, iHeadlights)
            If veh.HasBone("neon_b") Then
                giNeonKits = New UIMenuItem(LocalizedModGroupName(GroupName.NeonKits), Game.GetGXTEntry("CMOD_MOD_6_D"))
                gmLights.AddItem(giNeonKits)
                gmLights.BindMenuToItem(gmNeonKits, giNeonKits)
            End If
            gmLights.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshNeonKitsMenu()
        Try
            gmNeonKits.MenuItems.Clear()
            iNeon = New UIMenuItem(LocalizedModGroupName(GroupName.NeonLayout))
            gmNeonKits.AddItem(iNeon)
            gmNeonKits.BindMenuToItem(mNeon, iNeon)
            If Not veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                iNeonColor = New UIMenuItem(LocalizedModGroupName(GroupName.NeonColor), Game.GetGXTEntry("CMOD_MOD_6_D"))
                gmNeonKits.AddItem(iNeonColor)
                gmNeonKits.BindMenuToItem(mNeonColor, iNeonColor)
            End If
            gmNeonKits.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshNeonMenu()
        Try
            mNeon.MenuItems.Clear()

            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_0"))
            With iNeon
                .SubInteger1 = NeonLayouts.None
                If NeonLayout() = NeonLayouts.None Then .SetRightBadge(UIMenuItem.BadgeStyle.Car)
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_1"))
            With iNeon
                .SubInteger1 = NeonLayouts.Front
                If NeonLayout() = NeonLayouts.Front Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 1000
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 1000
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_2"))
            With iNeon
                .SubInteger1 = NeonLayouts.Back
                If NeonLayout() = NeonLayouts.Back Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 1000
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 1000
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_3"))
            With iNeon
                .SubInteger1 = NeonLayouts.Sides
                If NeonLayout() = NeonLayouts.Sides Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 1250
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 1250
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_4"))
            With iNeon
                .SubInteger1 = NeonLayouts.FrontAndBack
                If NeonLayout() = NeonLayouts.FrontAndBack Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 1800
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 1800
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_5"))
            With iNeon
                .SubInteger1 = NeonLayouts.FrontAndSides
                If NeonLayout() = NeonLayouts.FrontAndSides Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 2000
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 2000
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_6"))
            With iNeon
                .SubInteger1 = NeonLayouts.BackAndSides
                If NeonLayout() = NeonLayouts.BackAndSides Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 2000
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 2000
                End If
            End With
            mNeon.AddItem(iNeon)
            iNeon = New UIMenuItem(Game.GetGXTEntry("CMOD_NEONLAY_7"))
            With iNeon
                .SubInteger1 = NeonLayouts.FrontBackAndSides
                If NeonLayout() = NeonLayouts.FrontBackAndSides Then
                    .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                Else
                    Dim value As Integer = 3000
                    Dim price As String = "$" & value
                    .SetRightLabel(price)
                    .SubInteger2 = 3000
                End If
            End With
            mNeon.AddItem(iNeon)

            mNeon.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshResprayMenu()
        Try
            gmRespray.MenuItems.Clear()
            giPrimaryCol = New UIMenuItem(LocalizedModGroupName(GroupName.PrimaryColor), Game.GetGXTEntry("CMOD_MOD_6_D"))
            gmRespray.AddItem(giPrimaryCol)
            gmRespray.BindMenuToItem(mPrimaryColor, giPrimaryCol)
            giSecondaryCol = New UIMenuItem(LocalizedModGroupName(GroupName.SecondaryColor), Game.GetGXTEntry("CMOD_MOD_6_D"))
            gmRespray.AddItem(giSecondaryCol)
            gmRespray.BindMenuToItem(mSecondaryColor, giSecondaryCol)
            If Not bennysvehicle.Contains(veh.Model) Then
                iDashboardColor = New UIMenuItem(LocalizedModGroupName(GroupName.AccentColor), Game.GetGXTEntry("CMOD_MOD_6_D"))
                gmRespray.AddItem(iDashboardColor)
                gmRespray.BindMenuToItem(mLightsColor, iDashboardColor)
                iTrimColor = New UIMenuItem(LocalizedModGroupName(GroupName.TrimColor), Game.GetGXTEntry("CMOD_MOD_6_D")) 'trim color
                gmRespray.AddItem(iTrimColor)
                gmRespray.BindMenuToItem(mTrimColor, iTrimColor)
            End If
            gmRespray.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshPrimaryColorMenu()
        Try
            mPrimaryColor.MenuItems.Clear()
            iPrimaryChromeColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Chrome), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryChromeColor)
            mPrimaryColor.BindMenuToItem(mPrimaryChromeColor, iPrimaryChromeColor)
            iPrimaryClassicColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Classic), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryClassicColor)
            mPrimaryColor.BindMenuToItem(mPrimaryClassicColor, iPrimaryClassicColor)
            iPrimaryMatteColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Matte), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryMatteColor)
            mPrimaryColor.BindMenuToItem(mPrimaryMatteColor, iPrimaryMatteColor)
            iPrimaryMetallicColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Metallic), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryMetallicColor)
            mPrimaryColor.BindMenuToItem(mPrimaryMetallicColor, iPrimaryMetallicColor)
            iPrimaryMetalsColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Metals), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryMetalsColor)
            mPrimaryColor.BindMenuToItem(mPrimaryMetalsColor, iPrimaryMetalsColor)
            iPrimaryPearlescentColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Pearlescent), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mPrimaryColor.AddItem(iPrimaryPearlescentColor)
            mPrimaryColor.BindMenuToItem(mPrimaryPearlescentColor, iPrimaryPearlescentColor)
            mPrimaryColor.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshSecondaryColorMenu()
        Try
            mSecondaryColor.MenuItems.Clear()
            iSecondaryChromeColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Chrome), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mSecondaryColor.AddItem(iSecondaryChromeColor)
            mSecondaryColor.BindMenuToItem(mSecondaryChromeColor, iSecondaryChromeColor)
            iSecondaryClassicColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Classic), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mSecondaryColor.AddItem(iSecondaryClassicColor)
            mSecondaryColor.BindMenuToItem(mSecondaryClassicColor, iSecondaryClassicColor)
            iSecondaryMatteColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Matte), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mSecondaryColor.AddItem(iSecondaryMatteColor)
            mSecondaryColor.BindMenuToItem(mSecondaryMatteColor, iSecondaryMatteColor)
            iSecondaryMetallicColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Metallic), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mSecondaryColor.AddItem(iSecondaryMetallicColor)
            mSecondaryColor.BindMenuToItem(mSecondaryMetallicColor, iSecondaryMetallicColor)
            iSecondaryMetalsColor = New UIMenuItem(LocalizedColorGroupName(ColorType.Metals), Game.GetGXTEntry("CMOD_MOD_6_D"))
            mSecondaryColor.AddItem(iSecondaryMetalsColor)
            mSecondaryColor.BindMenuToItem(mSecondaryMetalsColor, iSecondaryMetalsColor)
            mSecondaryColor.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshColorMenuFor(ByRef menu As UIMenu, ByRef item As UIMenuItem, ByRef colorList As List(Of VehicleColor), prisecpear As String)
        Try
            menu.MenuItems.Clear()
            For Each col As VehicleColor In colorList
                item = New UIMenuItem(GetLocalizedColorName(col))
                With item
                    .SubInteger1 = col
                    If prisecpear = "Primary" Then
                        If veh.PrimaryColor = col Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        Else
                            Dim value As Integer = 2000
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 2000
                        End If
                    ElseIf prisecpear = "Secondary" Then
                        If veh.SecondaryColor = col Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        Else
                            Dim value As Integer = 2000
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 2000
                        End If
                    ElseIf prisecpear = "Pearlescent" Then
                        If veh.PearlescentColor = col Then
                            .SetRightBadge(UIMenuItem.BadgeStyle.Car)
                        Else
                            Dim value As Integer = 2000
                            Dim price As String = "$" & value
                            item.SetRightLabel(price)
                            .SubInteger2 = 2000
                        End If
                    End If
                End With
                menu.AddItem(item)
            Next
            menu.RefreshIndex()
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshMainMenu()
        Try
            MainMenu.MenuItems.Clear()

            If veh.IsDamaged Then
                iRepair = New UIMenuItem(LocalizedModGroupName(GroupName.Repair), Game.GetGXTEntry("CMOD_MOD_0_D")) 'Repair
                With iRepair
                    .SetRightLabel("$" & veh.GetRepairPrice)
                    .SubInteger1 = veh.GetRepairPrice
                End With
                MainMenu.AddItem(iRepair)
                MainMenu.RefreshIndex()
                PlaySpeech("SHOP_SELL_REPAIR")
            ElseIf veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                'Specials
                If lowriders.Contains(veh.Model) Then
                    iUpgrade = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade), Game.GetGXTEntry("CMOD_MOD_100_D")) 'Upgrade
                    With iUpgrade
                        .SetRightLabel("$" & veh.Model.GetUpgradePrice)
                        .SubInteger1 = veh.Model.GetUpgradePrice
                    End With
                    MainMenu.AddItem(iUpgrade)
                End If
                If veh.DisplayName.IsUpgradeModExist Then
                    Dim upgrade2 As Tuple(Of String, Integer) = veh.DisplayName.GetUpgradeModVehicleInfo
                    iUpgradeMod = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade), Game.GetGXTEntry("CMOD_MOD_100_D"))
                    With iUpgradeMod
                        .SetRightLabel("$" & upgrade2.Item2)
                        .SubInteger1 = upgrade2.Item2
                    End With
                    MainMenu.AddItem(iUpgradeMod)
                End If
                If arenawar.Contains(veh.Model) Then
                    iUpgradeAW = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade2), Game.GetGXTEntry("collision_87oubis")) 'Arena War Upgrade
                    MainMenu.AddItem(iUpgradeAW)
                    MainMenu.BindMenuToItem(mUpgradeAW, iUpgradeAW)
                End If

                If arenavehicle.Contains(veh.Model) Then 'Arena Vehicles
                    'Groups
                    If (veh.GetModCount(VehicleMod.ArchCover) <> 0 Or veh.GetModCount(VehicleMod.RightFender) <> 0 Or veh.GetModCount(VehicleMod.Tank) <> 0 Or veh.GetModCount(VehicleMod.Roof) <> 0) Then
                        giWeapon = New UIMenuItem(LocalizedModGroupName(GroupName.Weapons), Game.GetGXTEntry("CMOD_WEAPO_D")) 'weapons
                        MainMenu.AddItem(giWeapon)
                        MainMenu.BindMenuToItem(gmWeapon, giWeapon)
                    End If
                    If (veh.GetModCount(VehicleMod.Plaques) <> 0 Or veh.GetModCount(VehicleMod.Frame) <> 0 Or veh.GetModCount(VehicleMod.Aerials) <> 0 Or veh.GetModCount(VehicleMod.Trim) <> 0 Or veh.GetModCount(VehicleMod.VanityPlates) <> 0 Or veh.GetModCount(VehicleMod.Ornaments) <> 0) Then
                        giBodyworkArena = New UIMenuItem(LocalizedModGroupName(GroupName.Bodyworks), Game.GetGXTEntry("IE_BO_DT1")) 'bodywork arena
                        MainMenu.AddItem(giBodyworkArena)
                        MainMenu.BindMenuToItem(gmBodyworkArena, giBodyworkArena)
                    End If
                    If (veh.GetModCount(VehicleMod.Engine) <> 0 Or veh.GetModCount(VehicleMod.EngineBlock)) Then
                        giEngine = New UIMenuItem(LocalizedModGroupName(GroupName.Engine), Game.GetGXTEntry("CMOD_SMOD_2_D")) 'engine
                        MainMenu.AddItem(giEngine)
                        MainMenu.BindMenuToItem(gmEngine, giEngine)
                    End If

                    'Single Item
                    If veh.GetModCount(VehicleMod.AirFilter) <> 0 Then
                        giAirfilter = New UIMenuItem(LocalizedModTypeName(VehicleMod.AirFilter), Game.GetGXTEntry("SMOD_ENGINE_2"))
                        MainMenu.AddItem(giAirfilter)
                        MainMenu.BindMenuToItem(mAirFilter, giAirfilter)
                    End If
                    If veh.GetModCount(VehicleMod.Struts) <> 0 Then
                        giStruts = New UIMenuItem(LocalizedModTypeName(VehicleMod.Struts), Game.GetGXTEntry("SMOD_ENGINE_3b"))
                        MainMenu.AddItem(giStruts)
                        MainMenu.BindMenuToItem(mStruts, giStruts)
                    End If
                    If veh.GetModCount(VehicleMod.PlateHolder) <> 0 Then
                        giPlateHolder = New UIMenuItem(LocalizedModTypeName(VehicleMod.PlateHolder), Game.GetGXTEntry("CMOD_MOD_49_D"))
                        MainMenu.AddItem(giPlateHolder)
                        MainMenu.BindMenuToItem(mPlateHolder, giPlateHolder)
                    End If
                    If veh.GetModCount(VehicleMod.Speakers) <> 0 Then
                        iSpeaker = New UIMenuItem(LocalizedModTypeName(VehicleMod.Speakers), Game.GetGXTEntry("CMOD_MOD_58_D"))
                        MainMenu.AddItem(iSpeaker)
                        MainMenu.BindMenuToItem(mSpeakers, iSpeaker)
                    End If
                    giNumberPlate = New UIMenuItem(LocalizedModGroupName(GroupName.License), Game.GetGXTEntry("CMOD_MOD_18_D")) 'Number Plate
                    MainMenu.AddItem(giNumberPlate)
                    MainMenu.BindMenuToItem(mNumberPlate, giNumberPlate)
                Else 'Bennys and regular motorcycles
                    'Groups
                    If (veh.GetModCount(VehicleMod.Fender) <> 0 Or veh.GetModCount(VehicleMod.FrontBumper) <> 0 Or veh.GetModCount(VehicleMod.Hood) <> 0 Or veh.GetModCount(VehicleMod.Grille) <> 0 _
                        Or veh.GetModCount(VehicleMod.RearBumper) <> 0 Or veh.GetModCount(VehicleMod.Roof) <> 0 Or veh.GetModCount(VehicleMod.Spoilers) <> 0) Then
                        giBodywork = New UIMenuItem(LocalizedModGroupName(GroupName.Bodyworks), Game.GetGXTEntry("IE_BO_DT1")) 'bodywork
                        MainMenu.AddItem(giBodywork)
                        MainMenu.BindMenuToItem(gmBodywork, giBodywork)
                    End If
                    If (veh.GetModCount(VehicleMod.Engine) <> 0 Or veh.GetModCount(VehicleMod.Frame) <> 0 Or veh.GetModCount(VehicleMod.SideSkirt) <> 0) Or veh.CanInstallNitroMod Then
                        giEngine = New UIMenuItem(LocalizedModGroupName(GroupName.Engine), Game.GetGXTEntry("CMOD_SMOD_2_D")) 'engine
                        MainMenu.AddItem(giEngine)
                        MainMenu.BindMenuToItem(gmEngine, giEngine)
                    End If
                    giPlate = New UIMenuItem(LocalizedModGroupName(GroupName.Plate), Game.GetGXTEntry("CMOD_MOD_18_D")) 'Plate
                    MainMenu.AddItem(giPlate)
                    MainMenu.BindMenuToItem(gmPlate, giPlate)
                End If

                giWheels = New UIMenuItem(LocalizedModGroupName(GroupName.Wheels), Game.GetGXTEntry("CMOD_MOD_60_D"))
                MainMenu.AddItem(giWheels)
                MainMenu.BindMenuToItem(gmWheels, giWheels)
                giLights = New UIMenuItem(LocalizedModGroupName(GroupName.Lights), Game.GetGXTEntry("CMOD_MOD_15_D"))  'CMOD_MOD_47_D
                MainMenu.AddItem(giLights)
                MainMenu.BindMenuToItem(gmLights, giLights)
                giRespray = New UIMenuItem(LocalizedModGroupName(GroupName.Respray), Game.GetGXTEntry("CMOD_MOD_6_D"))
                MainMenu.AddItem(giRespray)
                MainMenu.BindMenuToItem(gmRespray, giRespray)

                'Single Item
                If veh.GetModCount(VehicleMod.Armor) <> 0 Then
                    iArmor = New UIMenuItem(LocalizedModTypeName(VehicleMod.Armor), Game.GetGXTEntry("CMOD_MOD_1_D"))
                    MainMenu.AddItem(iArmor)
                    MainMenu.BindMenuToItem(mArmor, iArmor)
                End If
                If veh.GetModCount(VehicleMod.Brakes) <> 0 Then
                    giBrakes = New UIMenuItem(LocalizedModTypeName(VehicleMod.Brakes), Game.GetGXTEntry("CMOD_MOD_3_D"))
                    MainMenu.AddItem(giBrakes)
                    MainMenu.BindMenuToItem(mBrakes, giBrakes)
                End If
                If veh.GetModCount(VehicleMod.Exhaust) <> 0 Then
                    giExhaust = New UIMenuItem(LocalizedModTypeName(VehicleMod.Exhaust), Game.GetGXTEntry("CMOD_MOD_16_D"))
                    MainMenu.AddItem(giExhaust)
                    MainMenu.BindMenuToItem(mExhaust, giExhaust)
                End If
                If veh.GetModCount(VehicleMod.Horns) <> 0 Then
                    iHorn = New UIMenuItem(LocalizedModTypeName(VehicleMod.Horns), Game.GetGXTEntry("CMOD_MOD_14_D"))
                    MainMenu.AddItem(iHorn)
                    MainMenu.BindMenuToItem(mHorn, iHorn)
                End If
                If veh.GetModCount(VehicleMod.Hydraulics) <> 0 Then
                    giHydraulics = New UIMenuItem(LocalizedModTypeName(VehicleMod.Hydraulics), Game.GetGXTEntry("CMOD_SMOD_5_D"))
                    MainMenu.AddItem(giHydraulics)
                    MainMenu.BindMenuToItem(mHydraulics, giHydraulics)
                End If
                If veh.GetModCount(VehicleMod.Livery) <> 0 Then
                    iLivery = New UIMenuItem(LocalizedModTypeName(VehicleMod.Livery), Game.GetGXTEntry("CMOD_SMOD_6_D"))
                    MainMenu.AddItem(iLivery)
                    MainMenu.BindMenuToItem(mLivery, iLivery)
                End If
                If veh.Livery2Count <> 0 Then
                    iTornadoC = New UIMenuItem(LocalizedModTypeName(VehicleMod.Roof), Game.GetGXTEntry("CMOD_SMOD_6_D"))
                    MainMenu.AddItem(iTornadoC)
                    MainMenu.BindMenuToItem(mTornadoC, iTornadoC)
                End If
                If veh.GetModCount(VehicleMod.Plaques) <> 0 Then
                    giPlaques = New UIMenuItem(LocalizedModTypeName(VehicleMod.Plaques), Game.GetGXTEntry("SMOD_IN_PLAQUE"))
                    MainMenu.AddItem(giPlaques)
                    MainMenu.BindMenuToItem(mPlaques, giPlaques)
                End If
                If veh.GetModCount(VehicleMod.Suspension) <> 0 Then
                    iSuspension = New UIMenuItem(LocalizedModTypeName(VehicleMod.Suspension), Game.GetGXTEntry("CMOD_MOD_24_D"))
                    MainMenu.AddItem(iSuspension)
                    MainMenu.BindMenuToItem(mSuspension, iSuspension)
                End If
                If veh.GetModCount(VehicleMod.Transmission) <> 0 Then
                    iTransmission = New UIMenuItem(LocalizedModTypeName(VehicleMod.Transmission), Game.GetGXTEntry("CMOD_MOD_26_D"))
                    MainMenu.AddItem(iTransmission)
                    MainMenu.BindMenuToItem(mTransmission, iTransmission)
                End If
                If veh.GetModCount(VehicleMod.Trunk) <> 0 Then
                    giTrunk = New UIMenuItem(LocalizedModTypeName(VehicleMod.Trunk), Game.GetGXTEntry("CMOD_MOD_62_D"))
                    MainMenu.AddItem(giTrunk)
                    MainMenu.BindMenuToItem(mTrunk, giTrunk)
                End If
                iTurbo = New UIMenuItem(LocalizedModTypeName(VehicleToggleMod.Turbo), Game.GetGXTEntry("CMOD_MOD_27_D"))
                MainMenu.AddItem(iTurbo)
                MainMenu.BindMenuToItem(mTurbo, iTurbo)
                MainMenu.RefreshIndex()
            Else
                'Specials
                If lowriders.Contains(veh.Model) Then
                    iUpgrade = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade), Game.GetGXTEntry("CMOD_MOD_100_D")) 'Upgrade
                    With iUpgrade
                        .SetRightLabel("$" & veh.Model.GetUpgradePrice)
                        .SubInteger1 = veh.Model.GetUpgradePrice
                    End With
                    MainMenu.AddItem(iUpgrade)
                End If
                If veh.DisplayName.IsUpgradeModExist Then
                    Dim upgrade2 As Tuple(Of String, Integer) = veh.DisplayName.GetUpgradeModVehicleInfo
                    iUpgradeMod = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade), Game.GetGXTEntry("CMOD_MOD_100_D"))
                    With iUpgradeMod
                        .SetRightLabel("$" & upgrade2.Item2)
                        .SubInteger1 = upgrade2.Item2
                    End With
                    MainMenu.AddItem(iUpgradeMod)
                End If
                If arenawar.Contains(veh.Model) Then
                    iUpgradeAW = New UIMenuItem(LocalizedModGroupName(GroupName.Upgrade2), Game.GetGXTEntry("collision_87oubis")) 'Arena War Upgrade
                    MainMenu.AddItem(iUpgradeAW)
                    MainMenu.BindMenuToItem(mUpgradeAW, iUpgradeAW)
                End If


                If arenavehicle.Contains(veh.Model) Then 'Arena Vehicles
                    'Groups
                    If (veh.GetModCount(VehicleMod.ArchCover) <> 0 Or veh.GetModCount(VehicleMod.RightFender) <> 0 Or veh.GetModCount(VehicleMod.Tank) <> 0 Or veh.GetModCount(VehicleMod.Roof) <> 0) Then
                        giWeapon = New UIMenuItem(LocalizedModGroupName(GroupName.Weapons), Game.GetGXTEntry("CMOD_WEAPO_D")) 'weapons
                        MainMenu.AddItem(giWeapon)
                        MainMenu.BindMenuToItem(gmWeapon, giWeapon)
                    End If
                    If (veh.GetModCount(VehicleMod.Plaques) <> 0 Or veh.GetModCount(VehicleMod.Frame) <> 0 Or veh.GetModCount(VehicleMod.Aerials) <> 0 Or veh.GetModCount(VehicleMod.Trim) <> 0 Or veh.GetModCount(VehicleMod.VanityPlates) <> 0 Or veh.GetModCount(VehicleMod.Ornaments) <> 0) Then
                        giBodyworkArena = New UIMenuItem(LocalizedModGroupName(GroupName.Bodyworks), Game.GetGXTEntry("IE_BO_DT1")) 'bodywork arena
                        MainMenu.AddItem(giBodyworkArena)
                        MainMenu.BindMenuToItem(gmBodyworkArena, giBodyworkArena)
                    End If
                    If (veh.GetModCount(VehicleMod.Engine) <> 0 Or veh.GetModCount(VehicleMod.EngineBlock)) Then
                        giEngine = New UIMenuItem(LocalizedModGroupName(GroupName.Engine), Game.GetGXTEntry("CMOD_SMOD_2_D")) 'engine
                        MainMenu.AddItem(giEngine)
                        MainMenu.BindMenuToItem(gmEngine, giEngine)
                    End If

                    'Single Item
                    If veh.GetModCount(VehicleMod.AirFilter) <> 0 Then
                        giAirfilter = New UIMenuItem(LocalizedModTypeName(VehicleMod.AirFilter), Game.GetGXTEntry("SMOD_ENGINE_2"))
                        MainMenu.AddItem(giAirfilter)
                        MainMenu.BindMenuToItem(mAirFilter, giAirfilter)
                    End If
                    If veh.GetModCount(VehicleMod.Struts) <> 0 Then
                        giStruts = New UIMenuItem(LocalizedModTypeName(VehicleMod.Struts), Game.GetGXTEntry("SMOD_ENGINE_3b"))
                        MainMenu.AddItem(giStruts)
                        MainMenu.BindMenuToItem(mStruts, giStruts)
                    End If
                    If veh.GetModCount(VehicleMod.PlateHolder) <> 0 Then
                        giPlateHolder = New UIMenuItem(LocalizedModTypeName(VehicleMod.PlateHolder), Game.GetGXTEntry("CMOD_MOD_49_D"))
                        MainMenu.AddItem(giPlateHolder)
                        MainMenu.BindMenuToItem(mPlateHolder, giPlateHolder)
                    End If
                    If veh.GetModCount(VehicleMod.Speakers) <> 0 Then
                        iSpeaker = New UIMenuItem(LocalizedModTypeName(VehicleMod.Speakers), Game.GetGXTEntry("CMOD_MOD_58_D"))
                        MainMenu.AddItem(iSpeaker)
                        MainMenu.BindMenuToItem(mSpeakers, iSpeaker)
                    End If
                    giNumberPlate = New UIMenuItem(LocalizedModGroupName(GroupName.License), Game.GetGXTEntry("CMOD_MOD_18_D")) 'Number Plate
                    MainMenu.AddItem(giNumberPlate)
                    MainMenu.BindMenuToItem(mNumberPlate, giNumberPlate)
                Else 'Bennys and regular vehicles
                    'Groups
                    If (veh.GetModCount(VehicleMod.Aerials) <> 0 Or veh.GetModCount(VehicleMod.Trim) <> 0 Or veh.GetModCount(VehicleMod.Windows) <> 0 Or veh.GetModCount(VehicleMod.ArchCover) <> 0) Then
                        giBodywork = New UIMenuItem(LocalizedModGroupName(GroupName.Bodyworks), Game.GetGXTEntry("IE_BO_DT1")) 'bodywork
                        MainMenu.AddItem(giBodywork)
                        MainMenu.BindMenuToItem(gmBodywork, giBodywork)
                    End If
                    If (veh.GetModCount(VehicleMod.Engine) <> 0 Or veh.GetModCount(VehicleMod.EngineBlock) <> 0 Or veh.GetModCount(VehicleMod.AirFilter) <> 0 Or veh.GetModCount(VehicleMod.Struts) <> 0) Or veh.CanInstallNitroMod Then
                        giEngine = New UIMenuItem(LocalizedModGroupName(GroupName.Engine), Game.GetGXTEntry("CMOD_SMOD_2_D")) 'engine
                        MainMenu.AddItem(giEngine)
                        MainMenu.BindMenuToItem(gmEngine, giEngine)
                    End If
                    If (veh.GetModCount(VehicleMod.ColumnShifterLevers) <> 0 Or veh.GetModCount(VehicleMod.Dashboard) <> 0 Or veh.GetModCount(VehicleMod.DialDesign) <> 0 Or veh.GetModCount(VehicleMod.Ornaments) <> 0 _
                        Or veh.GetModCount(VehicleMod.Seats) <> 0 Or veh.GetModCount(VehicleMod.SteeringWheels) <> 0 Or veh.GetModCount(VehicleMod.TrimDesign) <> 0 Or veh.GetModCount(VehicleMod.DoorSpeakers) <> 0 _
                        Or veh.GetModCount(VehicleMod.Speakers) <> 0) Then
                        giInterior = New UIMenuItem(LocalizedModGroupName(GroupName.Interior), Game.GetGXTEntry("SMOD_IN_1")) 'interior
                        MainMenu.AddItem(giInterior)
                        MainMenu.BindMenuToItem(gmInterior, giInterior)
                    End If
                    giPlate = New UIMenuItem(LocalizedModGroupName(GroupName.Plate), Game.GetGXTEntry("CMOD_MOD_18_D")) 'Plate
                    MainMenu.AddItem(giPlate)
                    MainMenu.BindMenuToItem(gmPlate, giPlate)

                    'Single Item
                    If veh.GetModCount(VehicleMod.Frame) <> 0 Then
                        iFrame = New UIMenuItem(LocalizedModTypeName(VehicleMod.Frame), Game.GetGXTEntry("SMOD_ROLLCAGE_1"))
                        MainMenu.AddItem(iFrame)
                        MainMenu.BindMenuToItem(mFrame, iFrame)
                    End If
                    If veh.GetModCount(VehicleMod.RightFender) <> 0 Then
                        iRFender = New UIMenuItem(LocalizedModTypeName(VehicleMod.RightFender), Game.GetGXTEntry("CMOD_MOD_9_D"))
                        MainMenu.AddItem(iRFender)
                        MainMenu.BindMenuToItem(mRFender, iRFender)
                    End If
                    If veh.GetModCount(VehicleMod.Roof) <> 0 Then
                        iRoof = New UIMenuItem(LocalizedModTypeName(VehicleMod.Roof), Game.GetGXTEntry("CMOD_MOD_73_D"))
                        MainMenu.AddItem(iRoof)
                        MainMenu.BindMenuToItem(mRoof, iRoof)
                    End If
                    If veh.GetModCount(VehicleMod.Tank) <> 0 Then
                        giTank = New UIMenuItem(LocalizedModTypeName(VehicleMod.Tank), Game.GetGXTEntry("CMOD_MOD_45_D"))
                        MainMenu.AddItem(giTank)
                        MainMenu.BindMenuToItem(mTank, giTank)
                    End If
                    If veh.GetModCount(VehicleMod.Plaques) <> 0 Then
                        giPlaques = New UIMenuItem(LocalizedModTypeName(VehicleMod.Plaques), Game.GetGXTEntry("SMOD_IN_PLAQUE"))
                        MainMenu.AddItem(giPlaques)
                        MainMenu.BindMenuToItem(mPlaques, giPlaques)
                    End If
                End If

                If (veh.GetModCount(VehicleMod.FrontBumper) <> 0 Or veh.GetModCount(VehicleMod.RearBumper) <> 0 Or veh.GetModCount(VehicleMod.SideSkirt) <> 0) Then
                    giBumper = New UIMenuItem(LocalizedModGroupName(GroupName.Bumpers), Game.GetGXTEntry("CMOD_MOD_4_D")) 'bumper
                    MainMenu.AddItem(giBumper)
                    MainMenu.BindMenuToItem(gmBumper, giBumper)
                End If

                giWheels = New UIMenuItem(LocalizedModGroupName(GroupName.Wheels), Game.GetGXTEntry("CMOD_MOD_60_D"))
                MainMenu.AddItem(giWheels)
                MainMenu.BindMenuToItem(gmWheels, giWheels)
                giLights = New UIMenuItem(LocalizedModGroupName(GroupName.Lights), Game.GetGXTEntry("CMOD_MOD_15_D"))  'CMOD_MOD_47_D
                MainMenu.AddItem(giLights)
                MainMenu.BindMenuToItem(gmLights, giLights)
                giRespray = New UIMenuItem(LocalizedModGroupName(GroupName.Respray), Game.GetGXTEntry("CMOD_MOD_6_D"))
                MainMenu.AddItem(giRespray)
                MainMenu.BindMenuToItem(gmRespray, giRespray)

                'Single Item
                If veh.GetModCount(VehicleMod.Armor) <> 0 Then
                    iArmor = New UIMenuItem(LocalizedModTypeName(VehicleMod.Armor), Game.GetGXTEntry("CMOD_MOD_1_D"))
                    MainMenu.AddItem(iArmor)
                    MainMenu.BindMenuToItem(mArmor, iArmor)
                End If
                If veh.GetModCount(VehicleMod.Brakes) <> 0 Then
                    giBrakes = New UIMenuItem(LocalizedModTypeName(VehicleMod.Brakes), Game.GetGXTEntry("CMOD_MOD_3_D"))
                    MainMenu.AddItem(giBrakes)
                    MainMenu.BindMenuToItem(mBrakes, giBrakes)
                End If

                If veh.GetModCount(VehicleMod.Exhaust) <> 0 Then
                    giExhaust = New UIMenuItem(LocalizedModTypeName(VehicleMod.Exhaust), Game.GetGXTEntry("CMOD_MOD_16_D"))
                    MainMenu.AddItem(giExhaust)
                    MainMenu.BindMenuToItem(mExhaust, giExhaust)
                End If
                If veh.GetModCount(VehicleMod.Fender) <> 0 Then
                    iFender = New UIMenuItem(LocalizedModTypeName(VehicleMod.Fender), Game.GetGXTEntry("CMOD_MOD_9_D"))
                    MainMenu.AddItem(iFender)
                    MainMenu.BindMenuToItem(mFender, iFender)
                End If
                If veh.GetModCount(VehicleMod.Grille) <> 0 Then
                    giGrille = New UIMenuItem(LocalizedModTypeName(VehicleMod.Grille), Game.GetGXTEntry("SMOD_CHASS_2c"))
                    MainMenu.AddItem(giGrille)
                    MainMenu.BindMenuToItem(mGrille, giGrille)
                End If
                If veh.GetModCount(VehicleMod.Hood) <> 0 Then
                    giHood = New UIMenuItem(LocalizedModTypeName(VehicleMod.Hood), Game.GetGXTEntry("CMOD_MOD_72_D"))
                    MainMenu.AddItem(giHood)
                    MainMenu.BindMenuToItem(mHood, giHood)
                End If
                If veh.GetModCount(VehicleMod.Horns) <> 0 Then
                    iHorn = New UIMenuItem(LocalizedModTypeName(VehicleMod.Horns), Game.GetGXTEntry("CMOD_MOD_14_D"))
                    MainMenu.AddItem(iHorn)
                    MainMenu.BindMenuToItem(mHorn, iHorn)
                End If
                If veh.GetModCount(VehicleMod.Hydraulics) <> 0 Then
                    giHydraulics = New UIMenuItem(LocalizedModTypeName(VehicleMod.Hydraulics), Game.GetGXTEntry("CMOD_SMOD_5_D"))
                    MainMenu.AddItem(giHydraulics)
                    MainMenu.BindMenuToItem(mHydraulics, giHydraulics)
                End If
                If veh.GetModCount(VehicleMod.Livery) <> 0 Then
                    iLivery = New UIMenuItem(LocalizedModTypeName(VehicleMod.Livery), Game.GetGXTEntry("CMOD_SMOD_6_D"))
                    MainMenu.AddItem(iLivery)
                    MainMenu.BindMenuToItem(mLivery, iLivery)
                End If
                If veh.Livery2Count <> 0 Then
                    iTornadoC = New UIMenuItem(LocalizedModTypeName(VehicleMod.Roof), Game.GetGXTEntry("CMOD_MOD_73_D"))
                    MainMenu.AddItem(iTornadoC)
                    MainMenu.BindMenuToItem(mTornadoC, iTornadoC)
                End If

                If veh.GetModCount(VehicleMod.Spoilers) <> 0 Then
                    giSpoilers = New UIMenuItem(LocalizedModTypeName(VehicleMod.Spoilers), Game.GetGXTEntry("CMOD_MOD_37_D"))
                    MainMenu.AddItem(giSpoilers)
                    MainMenu.BindMenuToItem(mSpoilers, giSpoilers)
                End If
                If veh.GetModCount(VehicleMod.Suspension) <> 0 Then
                    iSuspension = New UIMenuItem(LocalizedModTypeName(VehicleMod.Suspension), Game.GetGXTEntry("CMOD_MOD_24_D"))
                    MainMenu.AddItem(iSuspension)
                    MainMenu.BindMenuToItem(mSuspension, iSuspension)
                End If

                If veh.GetModCount(VehicleMod.Transmission) <> 0 Then
                    iTransmission = New UIMenuItem(LocalizedModTypeName(VehicleMod.Transmission), Game.GetGXTEntry("CMOD_MOD_26_D"))
                    MainMenu.AddItem(iTransmission)
                    MainMenu.BindMenuToItem(mTransmission, iTransmission)
                End If
                If veh.GetModCount(VehicleMod.Trunk) <> 0 Then
                    giTrunk = New UIMenuItem(LocalizedModTypeName(VehicleMod.Trunk), Game.GetGXTEntry("CMOD_MOD_62_D"))
                    MainMenu.AddItem(giTrunk)
                    MainMenu.BindMenuToItem(mTrunk, giTrunk)
                End If
                iTurbo = New UIMenuItem(LocalizedModTypeName(VehicleToggleMod.Turbo), Game.GetGXTEntry("CMOD_MOD_27_D"))
                MainMenu.AddItem(iTurbo)
                MainMenu.BindMenuToItem(mTurbo, iTurbo)
                If veh.HasBone("windscreen") Then
                    iTint = New UIMenuItem(LocalizedModGroupName(GroupName.Windows), Game.GetGXTEntry("CMOD_MOD_29_D"))
                    MainMenu.AddItem(iTint)
                    MainMenu.BindMenuToItem(mTint, iTint)
                End If
                MainMenu.RefreshIndex()
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
#End Region

    Public Sub CreateMenus()
        QuitMenu = QuitMenu.NewUIMenu("CMOD_MOD_E", False, False, AddressOf MainMenuCloseHandler, AddressOf MainMenuItemSelectHandler, itemName:=Game.GetGXTEntry("ITEM_EXIT"), itemDesc:=Game.GetGXTEntry("collision_6p1r1v"))
        MainMenu = MainMenu.NewUIMenu("CMOD_MOD_T", False, True, AddressOf MainMenuCloseHandler, AddressOf MainMenuItemSelectHandler)
        mUpgradeAW = mUpgradeAW.NewUIMenu("collision_9znude7", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler, indexChangeHandler:=AddressOf ArenaWarMenuIndexChangedHandler)
        gmBodywork = gmBodywork.NewUIMenu("CMOD_BW_T", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        gmBodyworkArena = gmBodyworkArena.NewUIMenu("CMOD_BW_T", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        gmWeapon = gmWeapon.NewUIMenu("PM_SCR_WEA", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mAerials = mAerials.NewUIMenu("CMM_MOD_ST18", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTrim = mTrim.NewUIMenu("CMM_MOD_ST19", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mWindow = mWindow.NewUIMenu("CMM_MOD_ST21", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mArchCover = mArchCover.NewUIMenu("CMM_MOD_ST17", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmEngine = gmEngine.NewUIMenu("CMM_MOD_GT3", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler)
        mEngine = mEngine.NewUIMenu("CMM_MOD_GT3", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mNitro = mNitro.NewUIMenu("CMM_MOD_TBOS", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mEngineBlock = mEngineBlock.NewUIMenu("CMOD_EB_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mAirFilter = mAirFilter.NewUIMenu("CMM_MOD_ST15", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mStruts = mStruts.NewUIMenu("CMM_MOD_ST16", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmInterior = gmInterior.NewUIMenu("CMM_MOD_GT1", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler)
        mColumnShifterLevers = mColumnShifterLevers.NewUIMenu("CMM_MOD_ST9", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mDashboard = mDashboard.NewUIMenu("CMM_MOD_ST4", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mLightsColor = mLightsColor.NewUIMenu("CMM_MOD_ST26", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mDialDesign = mDialDesign.NewUIMenu("CMM_MOD_ST5", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mOrnaments = mOrnaments.NewUIMenu("CMM_MOD_ST3", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSeats = mSeats.NewUIMenu("CMM_MOD_ST7", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSteeringWheels = mSteeringWheels.NewUIMenu("CMM_MOD_ST8", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTrimDesign = mTrimDesign.NewUIMenu("CMM_MOD_ST2", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTrimColor = mTrimColor.NewUIMenu("CMOD_MOD_TRIM2", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mDoor = mDoor.NewUIMenu("CMM_MOD_ST6", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmBumper = gmBumper.NewUIMenu("CMOD_BUM_T", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mFBumper = mFBumper.NewUIMenu("CMOD_BUMF_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mRBumper = mRBumper.NewUIMenu("CMOD_BUMR_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSSkirt = mSSkirt.NewUIMenu("CMOD_SS_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmWheels = gmWheels.NewUIMenu("CMOD_WHE0_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf WheelsMenuItemSelectHandler)
        gmWheelType = gmWheelType.NewUIMenu("CMOD_WHE1_T", False, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        gmBikeWheels = gmBikeWheels.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.BikeWheels).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSBikeWheels = mSBikeWheels.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.BikeWheels).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCBikeWheels = mCBikeWheels.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.BikeWheels).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmHighEnd = gmHighEnd.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.HighEnd).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSHighEnd = mSHighEnd.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.HighEnd).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCHighEnd = mCHighEnd.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.HighEnd).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmLowrider = gmLowrider.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Lowrider).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSLowrider = mSLowrider.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Lowrider).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCLowrider = mCLowrider.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Lowrider).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmMuscle = gmMuscle.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Muscle).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSMuscle = mSMuscle.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Muscle).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCMuscle = mCMuscle.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Muscle).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmOffroad = gmOffroad.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Offroad).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSOffroad = mSOffroad.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Offroad).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCOffroad = mCOffroad.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Offroad).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmSport = gmSport.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Sport).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSSport = mSSport.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Sport).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCSport = mCSport.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Sport).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmSUV = gmSUV.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.SUV).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSSUV = mSSUV.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.SUV).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCSUV = mCSUV.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.SUV).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmTuner = gmTuner.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Tuner).ToUpper, True, selectHandler:=AddressOf ModsMenuItemSelectHandler)
        mSTuner = mSTuner.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Tuner).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mCTuner = mCTuner.NewUIMenu(GetLocalizedWheelTypeName(VehicleWheelType.Tuner).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBennysOriginals = mBennysOriginals.NewUIMenu(GetLocalizedWheelTypeName(8).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBespoke = mBespoke.NewUIMenu(GetLocalizedWheelTypeName(9).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mRimColor = mRimColor.NewUIMenu(LocalizedModGroupName(GroupName.WheelColor).ToUpper, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTires = mTires.NewUIMenu("CMOD_TYR_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTireSmoke = mTireSmoke.NewUIMenu("CMOD_MOD_TYR3", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmPlate = gmPlate.NewUIMenu("CMM_MOD_GT2", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler)
        mPlateHolder = mPlateHolder.NewUIMenu("CMOD_PLH_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mVanityPlates = mVanityPlates.NewUIMenu("CMM_MOD_ST1", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mNumberPlate = mNumberPlate.NewUIMenu("CMOD_MOD_PLA2", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmLights = gmLights.NewUIMenu("CMOD_LGT_T", False, True, AddressOf ModsMenuCloseHandler)
        mHeadlights = mHeadlights.NewUIMenu("CMOD_HED_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmNeonKits = gmNeonKits.NewUIMenu("CMOD_MOD_LGT_N", True, True)
        mNeon = mNeon.NewUIMenu("CMOD_NEON_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mNeonColor = mNeonColor.NewUIMenu("CMOD_NEON_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        gmRespray = gmRespray.NewUIMenu("CMOD_COL0_T", False, True)
        mPrimaryColor = mPrimaryColor.NewUIMenu("CMOD_COL1_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryClassicColor = mPrimaryClassicColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryChromeColor = mPrimaryChromeColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryMetallicColor = mPrimaryMetallicColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryMetalsColor = mPrimaryMetalsColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryMatteColor = mPrimaryMatteColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPrimaryPearlescentColor = mPrimaryPearlescentColor.NewUIMenu("CMOD_COL0_0", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryColor = mSecondaryColor.NewUIMenu("CMOD_COL1_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryClassicColor = mSecondaryClassicColor.NewUIMenu("CMOD_COL0_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryChromeColor = mSecondaryChromeColor.NewUIMenu("CMOD_COL0_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryMetallicColor = mSecondaryMetallicColor.NewUIMenu("CMOD_COL0_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryMetalsColor = mSecondaryMetalsColor.NewUIMenu("CMOD_COL0_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSecondaryMatteColor = mSecondaryMatteColor.NewUIMenu("CMOD_COL0_1", True, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mExhaust = mExhaust.NewUIMenu("CMOD_EXH_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mFender = mFender.NewUIMenu("CMOD_WNG_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mRFender = mRFender.NewUIMenu("CMOD_WNG_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mFrame = mFrame.NewUIMenu("CMOD_RC_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mGrille = mGrille.NewUIMenu("CMOD_GRL_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mHood = mHood.NewUIMenu("CMOD_BON_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mHorn = mHorn.NewUIMenu("CMOD_HRN_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mHydraulics = mHydraulics.NewUIMenu("CMM_MOD_ST13", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mLivery = mLivery.NewUIMenu("CMM_MOD_ST23", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTornadoC = mTornadoC.NewUIMenu("CMOD_ROF_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mPlaques = mPlaques.NewUIMenu("CMM_MOD_ST10", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mRoof = mRoof.NewUIMenu("CMOD_ROF_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSpeakers = mSpeakers.NewUIMenu("CMM_MOD_S11", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSpoilers = mSpoilers.NewUIMenu("CMOD_SPO_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTank = mTank.NewUIMenu("CMM_MOD_ST20", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTrunk = mTrunk.NewUIMenu("CMOD_TR_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTurbo = mTurbo.NewUIMenu("CMOD_TUR_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mSuspension = mSuspension.NewUIMenu("CMOD_SUS_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mArmor = mArmor.NewUIMenu("CMOD_ARM_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBrakes = mBrakes.NewUIMenu("CMOD_BRA_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTransmission = mTransmission.NewUIMenu("CMOD_GBX_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mTint = mTint.NewUIMenu("CMOD_WIN_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        'Motorcycles
        mShifter = mShifter.NewUIMenu("CMOD_SHIFTER_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mFMudguard = mFMudguard.NewUIMenu("CMOD_FMUD_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBSeat = mBSeat.NewUIMenu("CMM_MOD_ST7", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mOilTank = mOilTank.NewUIMenu("CMM_MOD_ST29", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mRMudguard = mRMudguard.NewUIMenu("CMOD_RMUD_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mFuelTank = mFuelTank.NewUIMenu("CMOD_FUL_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBeltDriveCovers = mBeltDriveCovers.NewUIMenu("CMOD_MOD_BLT", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBEngineBlock = mBEngineBlock.NewUIMenu("CMOD_EB_T", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBAirFilter = mBAirFilter.NewUIMenu("CMM_MOD_ST15", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
        mBTank = mBTank.NewUIMenu("CMM_MOD_ST20", False, True, AddressOf ModsMenuCloseHandler, AddressOf ModsMenuItemSelectHandler, AddressOf ModsMenuIndexChangedHandler)
    End Sub

#Region "Menu Event Handlers"
    Public Sub WheelsMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        If sender Is gmWheels Then
            RefreshTyresMenu()
            If selectedItem Is iBPTires Then
                If iBPTires.RightBadge = UIMenuItem.BadgeStyle.Car Then
                    veh.CanTiresBurst = True
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.None)
                    lastVehMemory.BulletProofTires = True
                Else
                    veh.CanTiresBurst = False
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    lastVehMemory.BulletProofTires = False
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                End If
            End If
        End If
    End Sub

    Public Sub ModsMenuIndexChangedHandler(sender As UIMenu, index As Integer)
        Try
            'Performance
            If sender Is mSuspension Then
                veh.SetMod(VehicleMod.Suspension, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mArmor Then
                veh.SetMod(VehicleMod.Armor, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBrakes Then
                veh.SetMod(VehicleMod.Brakes, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTransmission Then
                veh.SetMod(VehicleMod.Transmission, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mEngine Then
                veh.SetMod(VehicleMod.Engine, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mNitro Then
                veh.SetBool(nitroMod, CBool(sender.MenuItems(index).SubInteger1))
            End If

            'Mod
            If sender Is mFBumper Then
                veh.SetMod(VehicleMod.FrontBumper, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mRBumper Then
                veh.SetMod(VehicleMod.RearBumper, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mSSkirt Then
                veh.SetMod(VehicleMod.SideSkirt, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mNumberPlate Then
                veh.NumberPlateType = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mHeadlights Then
                veh.ToggleMod(VehicleToggleMod.XenonHeadlights, CBool(sender.MenuItems(index).SubInteger1))
                If index = 0 Then veh.SetXenonHeadlightsColor(sender.MenuItems(index).SubInteger3, False) Else veh.SetXenonHeadlightsColor(sender.MenuItems(index).SubInteger3, True)
            ElseIf sender Is mArchCover Then
                veh.SetMod(VehicleMod.ArchCover, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mExhaust Then
                veh.SetMod(VehicleMod.Exhaust, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mFender Then
                veh.SetMod(VehicleMod.Fender, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mRFender Then
                veh.SetMod(VehicleMod.RightFender, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mDoor Then
                veh.SetMod(VehicleMod.DoorSpeakers, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mFrame Then
                veh.SetMod(VehicleMod.Frame, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mAerials Then
                veh.SetMod(VehicleMod.Aerials, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTrim Then
                veh.SetMod(VehicleMod.Trim, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mEngineBlock Then
                veh.SetMod(VehicleMod.EngineBlock, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mAirFilter Then
                veh.SetMod(VehicleMod.AirFilter, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mStruts Then
                veh.SetMod(VehicleMod.Struts, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mColumnShifterLevers Then
                veh.SetMod(VehicleMod.ColumnShifterLevers, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mDashboard Then
                veh.SetMod(VehicleMod.Dashboard, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mDialDesign Then
                veh.SetMod(VehicleMod.DialDesign, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mOrnaments Then
                veh.SetMod(VehicleMod.Ornaments, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mSeats Then
                veh.SetMod(VehicleMod.Seats, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mSteeringWheels Then
                veh.SetMod(VehicleMod.SteeringWheels, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTrimDesign Then
                veh.SetMod(VehicleMod.TrimDesign, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mPlateHolder Then
                veh.SetMod(VehicleMod.PlateHolder, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mVanityPlates Then
                veh.SetMod(VehicleMod.VanityPlates, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mGrille Then
                veh.SetMod(VehicleMod.Grille, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mHood Then
                veh.SetMod(VehicleMod.Hood, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mHorn Then
                veh.SetMod(VehicleMod.Horns, sender.MenuItems(index).SubInteger1, False)
                ply.Task.WarpIntoVehicle(veh, VehicleSeat.Passenger)
                veh.SoundHorn(3000)
            ElseIf sender Is mHydraulics Then
                veh.SetMod(VehicleMod.Hydraulics, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mLivery Then
                veh.SetMod(VehicleMod.Livery, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTornadoC Then
                veh.SetLivery2(sender.MenuItems(index).SubInteger1)
            ElseIf sender Is mPlaques Then
                veh.SetMod(VehicleMod.Plaques, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mRoof Then
                veh.SetMod(VehicleMod.Roof, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mSpeakers Then
                veh.SetMod(VehicleMod.Speakers, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mSpoilers Then
                veh.SetMod(VehicleMod.Spoilers, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTank Then
                veh.SetMod(VehicleMod.Tank, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTrunk Then
                veh.SetMod(VehicleMod.Trunk, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mWindow Then
                veh.SetMod(VehicleMod.Windows, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mTurbo Then
                veh.ToggleMod(VehicleToggleMod.Turbo, CBool(sender.MenuItems(index).SubInteger1))
            ElseIf sender Is mTint Then
                veh.WindowTint = sender.MenuItems(index).SubInteger1
            End If

            'Bike Mods
            If sender Is mShifter Then
                veh.SetMod(VehicleMod.Fender, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mFMudguard Then
                veh.SetMod(VehicleMod.FrontBumper, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBSeat Then
                veh.SetMod(VehicleMod.Hood, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mOilTank Then
                veh.SetMod(VehicleMod.Grille, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mRMudguard Then
                veh.SetMod(VehicleMod.RearBumper, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mFuelTank Then
                veh.SetMod(VehicleMod.Roof, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBeltDriveCovers Then
                veh.SetMod(VehicleMod.Spoilers, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBEngineBlock Then
                veh.SetMod(VehicleMod.Frame, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBAirFilter Then
                veh.SetMod(VehicleMod.SideSkirt, sender.MenuItems(index).SubInteger1, False)
            ElseIf sender Is mBTank Then
                veh.SetMod(VehicleMod.Tank, sender.MenuItems(index).SubInteger1, False)
            End If

            'Neons Mods
            If sender Is mNeon Then
                Select Case sender.MenuItems(index).SubInteger1
                    Case NeonLayouts.None
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                    Case NeonLayouts.Front
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                    Case NeonLayouts.Back
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                    Case NeonLayouts.Sides
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    Case NeonLayouts.FrontAndBack
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                    Case NeonLayouts.FrontAndSides
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    Case NeonLayouts.BackAndSides
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                    Case NeonLayouts.FrontBackAndSides
                        veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                        veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                End Select
            End If

            'Wheels Mods
            If (sender Is mSBikeWheels) Or (sender Is mCBikeWheels) Then 'gmBikeWheels
                veh.SetMod(VehicleMod.FrontWheels, sender.MenuItems(index).SubInteger1, False)
                veh.SetMod(VehicleMod.BackWheels, sender.MenuItems(index).SubInteger1, False)
            ElseIf (sender Is mSHighEnd) Or (sender Is mSLowrider) Or (sender Is mSMuscle) Or (sender Is mSOffroad) Or (sender Is mSSport) Or (sender Is mSSUV) Or (sender Is mSTuner) Or (sender Is mCHighEnd) Or (sender Is mCLowrider) Or (sender Is mCMuscle) Or (sender Is mCOffroad) Or (sender Is mCSport) Or (sender Is mCSUV) Or (sender Is mCTuner) Or (sender Is mBennysOriginals) Or (sender Is mBespoke) Then
                veh.SetMod(VehicleMod.FrontWheels, sender.MenuItems(index).SubInteger1, False)
            End If
            If sender Is mTires Then
                Select Case veh.WheelType
                    Case 8, 9
                        veh.SetMod(VehicleMod.FrontWheels, sender.MenuItems(index).SubInteger1, False)
                    Case Else
                        If sender.MenuItems(index).SubInteger1 = 1 Then
                            veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.FrontWheels), False)
                            If veh.ClassType = VehicleClass.Motorcycles Then veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.BackWheels), False)
                        ElseIf sender.MenuItems(index).SubInteger1 = 7 Then
                            veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.FrontWheels), True)
                            If veh.ClassType = VehicleClass.Motorcycles Then veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.BackWheels), True)
                        End If
                End Select
            End If

            'Color
            If sender Is mLightsColor Then
                veh.DashboardColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mTrimColor Then
                veh.TrimColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mRimColor Then
                veh.RimColor = sender.MenuItems(index).SubInteger1
            ElseIf (sender Is mPrimaryChromeColor) Or (sender Is mPrimaryClassicColor) Or (sender Is mPrimaryMatteColor) Or (sender Is mPrimaryMetalsColor) Then
                veh.PrimaryColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mPrimaryMetallicColor Then
                veh.PrimaryColor = sender.MenuItems(index).SubInteger1
                veh.PearlescentColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mPrimaryPearlescentColor Then
                veh.PearlescentColor = sender.MenuItems(index).SubInteger1
            ElseIf (sender Is mSecondaryChromeColor) Or (sender Is mSecondaryClassicColor) Or (sender Is mSecondaryMatteColor) Or (sender Is mSecondaryMetallicColor) Or (sender Is mSecondaryMetalsColor) Then
                veh.SecondaryColor = sender.MenuItems(index).SubInteger1
            ElseIf sender Is mNeonColor Then
                veh.NeonLightsColor = Drawing.Color.FromArgb(sender.MenuItems(index).SubInteger1, sender.MenuItems(index).SubInteger2, sender.MenuItems(index).SubInteger3)
            ElseIf sender Is mTireSmoke Then
                veh.TireSmokeColor = Drawing.Color.FromArgb(sender.MenuItems(index).SubInteger1, sender.MenuItems(index).SubInteger2, sender.MenuItems(index).SubInteger3)
                veh.ToggleMod(VehicleToggleMod.TireSmoke, True)
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ArenaWarMenuIndexChangedHandler(sender As UIMenu, index As Integer)
        Dim selecteditem As UIMenuItem = sender.MenuItems(index)
        arenaVehImage = selecteditem.SubString2
    End Sub

    Public Sub ModsMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            For Each i As UIMenuItem In sender.MenuItems
                i.SetRightBadge(UIMenuItem.BadgeStyle.None)
            Next

            'Arena War Upgrade
            If sender Is mUpgradeAW Then
                Game.FadeScreenOut(1000)
                Script.Wait(1000)
                Dim newAWVeh As Vehicle = World.CreateVehicle(selectedItem.SubString1, veh.Position, veh.Heading)
                newAWVeh.IsPersistent = False
                newAWVeh.PrimaryColor = lastVehMemory.PrimaryColor
                newAWVeh.SecondaryColor = lastVehMemory.SecondaryColor
                newAWVeh.DashboardColor = lastVehMemory.LightsColor
                newAWVeh.PearlescentColor = lastVehMemory.PearlescentColor
                newAWVeh.TrimColor = lastVehMemory.TrimColor
                newAWVeh.RimColor = lastVehMemory.RimColor
                newAWVeh.NeonLightsColor = lastVehMemory.NeonLightsColor
                newAWVeh.TireSmokeColor = lastVehMemory.TireSmokeColor
                newAWVeh.InstallModKit()
                newAWVeh.WheelType = lastVehMemory.WheelType
                newAWVeh.SetMod(VehicleMod.Aerials, lastVehMemory.Aerials, False)
                newAWVeh.SetMod(VehicleMod.AirFilter, lastVehMemory.AirFilter, False)
                newAWVeh.SetMod(VehicleMod.ArchCover, lastVehMemory.ArchCover, False)
                newAWVeh.SetMod(VehicleMod.Armor, lastVehMemory.Armor, False)
                newAWVeh.SetMod(VehicleMod.BackWheels, lastVehMemory.BackWheels, False)
                newAWVeh.SetMod(VehicleMod.Brakes, lastVehMemory.Brakes, False)
                newAWVeh.SetMod(VehicleMod.ColumnShifterLevers, lastVehMemory.ColumnShifterLevers, False)
                newAWVeh.SetMod(VehicleMod.Dashboard, lastVehMemory.Dashboard, False)
                newAWVeh.SetMod(VehicleMod.DialDesign, lastVehMemory.DialDesign, False)
                newAWVeh.SetMod(VehicleMod.DoorSpeakers, lastVehMemory.DoorSpeakers, False)
                newAWVeh.SetMod(VehicleMod.Engine, lastVehMemory.Engine, False)
                newAWVeh.SetMod(VehicleMod.EngineBlock, lastVehMemory.EngineBlock, False)
                newAWVeh.SetMod(VehicleMod.Exhaust, lastVehMemory.Exhaust, False)
                newAWVeh.SetMod(VehicleMod.Fender, lastVehMemory.Fender, False)
                newAWVeh.SetMod(VehicleMod.Frame, lastVehMemory.Frame, False)
                newAWVeh.SetMod(VehicleMod.FrontBumper, lastVehMemory.FrontBumper, False)
                newAWVeh.SetMod(VehicleMod.FrontWheels, lastVehMemory.FrontWheels, False)
                newAWVeh.SetMod(VehicleMod.Grille, lastVehMemory.Grille, False)
                newAWVeh.SetMod(VehicleMod.Hood, lastVehMemory.Hood, False)
                newAWVeh.SetMod(VehicleMod.Horns, lastVehMemory.Horns, False)
                newAWVeh.SetMod(VehicleMod.Hydraulics, lastVehMemory.Hydraulics, False)
                newAWVeh.SetMod(VehicleMod.Livery, lastVehMemory.Livery, False)
                newAWVeh.SetLivery2(lastVehMemory.Livery2)
                newAWVeh.SetMod(VehicleMod.Ornaments, lastVehMemory.Ornaments, False)
                newAWVeh.SetMod(VehicleMod.Plaques, lastVehMemory.Plaques, False)
                newAWVeh.SetMod(VehicleMod.PlateHolder, lastVehMemory.PlateHolder, False)
                newAWVeh.SetMod(VehicleMod.RearBumper, lastVehMemory.RearBumper, False)
                newAWVeh.SetMod(VehicleMod.RightFender, lastVehMemory.RightFender, False)
                newAWVeh.SetMod(VehicleMod.Roof, lastVehMemory.Roof, False)
                newAWVeh.SetMod(VehicleMod.Seats, lastVehMemory.Seats, False)
                newAWVeh.SetMod(VehicleMod.SideSkirt, lastVehMemory.SideSkirt, False)
                newAWVeh.SetMod(VehicleMod.Speakers, lastVehMemory.Speakers, False)
                newAWVeh.SetMod(VehicleMod.Spoilers, lastVehMemory.Spoilers, False)
                newAWVeh.SetMod(VehicleMod.SteeringWheels, lastVehMemory.SteeringWheels, False)
                newAWVeh.SetMod(VehicleMod.Struts, lastVehMemory.Struts, False)
                newAWVeh.SetMod(VehicleMod.Suspension, lastVehMemory.Suspension, False)
                newAWVeh.SetMod(VehicleMod.Tank, lastVehMemory.Tank, False)
                newAWVeh.SetMod(VehicleMod.Transmission, lastVehMemory.Transmission, False)
                newAWVeh.SetMod(VehicleMod.Trim, lastVehMemory.Trim, False)
                newAWVeh.SetMod(VehicleMod.TrimDesign, lastVehMemory.TrimDesign, False)
                newAWVeh.SetMod(VehicleMod.Trunk, lastVehMemory.Trunk, False)
                newAWVeh.SetMod(VehicleMod.VanityPlates, lastVehMemory.VanityPlates, False)
                newAWVeh.SetMod(VehicleMod.Windows, lastVehMemory.Windows, False)
                newAWVeh.ToggleMod(VehicleToggleMod.TireSmoke, True)
                newAWVeh.ToggleMod(VehicleToggleMod.Turbo, lastVehMemory.Turbo)
                newAWVeh.ToggleMod(VehicleToggleMod.XenonHeadlights, lastVehMemory.Headlights)
                newAWVeh.SetXenonHeadlightsColor(lastVehMemory.HeadlightsColor, newAWVeh.IsToggleModOn(VehicleToggleMod.XenonHeadlights))
                newAWVeh.NumberPlateType = lastVehMemory.NumberPlate
                newAWVeh.NumberPlate = lastVehMemory.PlateNumbers
                newAWVeh.CanTiresBurst = lastVehMemory.BulletProofTires
                veh.Delete()
                ply.Task.WarpIntoVehicle(veh, VehicleSeat.Driver)
                veh = veh
                veh.InstallModKit()
                MainMenu.MenuItems.Remove(iUpgradeAW)
                isRepairing = True
                RefreshMenus()
                camera.RepositionFor(veh)
                Script.Wait(1000)
                Game.FadeScreenIn(1000)
                Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger1)
                Native.Function.Call(Hash._START_SCREEN_EFFECT, "MP_corona_switch_supermod", 0, 1)
                Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lowrider_Upgrade", "Lowrider_Super_Mod_Garage_Sounds", 1)
                PlaySpeech("LR_UPGRADE_SUPERMOD")
            End If

            'Performance Mods
            If sender Is mSuspension Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Suspension, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Suspension = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_SUSPENSION")
                End If
            ElseIf sender Is mArmor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Armor, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Armor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_ARMOUR")
                End If
            ElseIf sender Is mBrakes Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Brakes, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Brakes = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_BRAKES")
                End If
            ElseIf sender Is mTransmission Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Transmission, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Transmission = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_TRANS_UPGRADE")
                End If
            ElseIf sender Is mEngine Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Engine, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Engine = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_ENGINE_UPGRADE")
                End If
            ElseIf sender Is mNitro Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetBool(nitroMod, CBool(selectedItem.SubInteger1))
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Nitro = CBool(selectedItem.SubInteger1)
                    PlaySpeech("SHOP_SELL_ENGINE_UPGRADE")
                End If
            End If

            'Mods
            If sender Is mFBumper Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.FrontBumper, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.FrontBumper = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mRBumper Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.RearBumper, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.RearBumper = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mSSkirt Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.SideSkirt, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.SideSkirt = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mNumberPlate Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.NumberPlateType = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.NumberPlate = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mHeadlights Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.ToggleMod(VehicleToggleMod.XenonHeadlights, CBool(selectedItem.SubInteger1))
                    If selectedItem.Text = Game.GetGXTEntry("CMOD_LGT_0") Then veh.SetXenonHeadlightsColor(selectedItem.SubInteger3, False) Else veh.SetXenonHeadlightsColor(selectedItem.SubInteger3, True)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Headlights = CBool(selectedItem.SubInteger1)
                    lastVehMemory.HeadlightsColor = selectedItem.SubInteger3
                    PlaySpeech("")
                End If
            ElseIf sender Is mArchCover Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.ArchCover, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.ArchCover = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mExhaust Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Exhaust, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Exhaust = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_EXHAUST")
                End If
            ElseIf sender Is mFender Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Fender, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Fender = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mRFender Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.RightFender, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.RightFender = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mDoor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.DoorSpeakers, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.DoorSpeakers = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mFrame Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Frame, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Frame = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_EXCHASSIS_MOD")
                End If
            ElseIf sender Is mAerials Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Aerials, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Aerials = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mTrim Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Trim, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Trim = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mEngineBlock Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.EngineBlock, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.EngineBlock = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_ENGINE")
                End If
            ElseIf sender Is mAirFilter Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.AirFilter, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.AirFilter = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_ENGINE")
                End If
            ElseIf sender Is mStruts Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Struts, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Struts = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mColumnShifterLevers Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.ColumnShifterLevers, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.ColumnShifterLevers = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_GEARKNOB")
                End If
            ElseIf sender Is mDashboard Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Dashboard, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Dashboard = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_SUPERMOD_INTERIOR")
                End If
            ElseIf sender Is mDialDesign Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.DialDesign, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.DialDesign = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_SUPERMOD_INTERIOR")
                End If
            ElseIf sender Is mOrnaments Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Ornaments, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Ornaments = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_DOLL")
                End If
            ElseIf sender Is mSeats Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Seats, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Seats = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_SUPERMOD_INTERIOR")
                End If
            ElseIf sender Is mSteeringWheels Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.SteeringWheels, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.SteeringWheels = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_SUPERMOD_INTERIOR")
                End If
            ElseIf sender Is mTrimDesign Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.TrimDesign, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.TrimDesign = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_SUPERMOD_INTERIOR")
                End If
            ElseIf sender Is mPlateHolder Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.PlateHolder, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.PlateHolder = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_PLATEHOLDER")
                End If
            ElseIf sender Is mVanityPlates Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.VanityPlates, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.VanityPlates = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_VANITYPLATE")
                End If
            ElseIf sender Is mGrille Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Grille, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Grille = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mHood Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Hood, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Hood = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mHorn Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Horns, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Horns = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_HORN")
                End If
            ElseIf sender Is mHydraulics Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Hydraulics, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Hydraulics = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_HYDRAULICS")
                End If
            ElseIf sender Is mLivery Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Livery, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Livery = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_LIVERY")
                End If
            ElseIf sender Is mTornadoC Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetLivery2(selectedItem.SubInteger1)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Livery2 = selectedItem.SubInteger1
                    PlaySpeech("LR_SELL_LIVERY")
                End If
            ElseIf sender Is mPlaques Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Plaques, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Plaques = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_PLAQUE")
                End If
            ElseIf sender Is mRoof Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Roof, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Roof = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mSpeakers Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Speakers, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Speakers = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_ICE")
                End If
            ElseIf sender Is mSpoilers Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Spoilers, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Spoilers = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mTank Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Tank, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Tank = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mTrunk Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Trunk, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Trunk = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_TRUNK")
                End If
            ElseIf sender Is mWindow Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Windows, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Windows = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mTurbo Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.ToggleMod(VehicleToggleMod.Turbo, CBool(selectedItem.SubInteger1))
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Turbo = CBool(selectedItem.SubInteger1)
                    PlaySpeech("SHOP_SELL_TURBO")
                End If
            ElseIf sender Is mTint Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.WindowTint = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Tint = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            End If

            'Bike Mods
            If sender Is mShifter Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Fender, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Fender = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mFMudguard Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.FrontBumper, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.FrontBumper = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mBSeat Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Hood, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Hood = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mOilTank Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Grille, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Grille = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mRMudguard Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.RearBumper, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.RearBumper = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mFuelTank Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Roof, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Roof = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mBeltDriveCovers Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Spoilers, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Spoilers = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mBEngineBlock Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Frame, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Frame = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mBAirFilter Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.SideSkirt, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.SideSkirt = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            ElseIf sender Is mBTank Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.Tank, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.Tank = selectedItem.SubInteger1
                    PlaySpeech("")
                End If
            End If

            'Neons Mods
            If sender Is mNeon Then
                Select Case selectedItem.SubInteger1
                    Case NeonLayouts.None
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = False
                            lastVehMemory.BackNeon = False
                            lastVehMemory.LeftNeon = False
                            lastVehMemory.RightNeon = False
                        End If
                    Case NeonLayouts.Front
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = True
                            lastVehMemory.BackNeon = False
                            lastVehMemory.LeftNeon = False
                            lastVehMemory.RightNeon = False
                        End If
                    Case NeonLayouts.Back
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = False
                            lastVehMemory.BackNeon = True
                            lastVehMemory.LeftNeon = False
                            lastVehMemory.RightNeon = False
                        End If
                    Case NeonLayouts.Sides
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = False
                            lastVehMemory.BackNeon = False
                            lastVehMemory.LeftNeon = True
                            lastVehMemory.RightNeon = True
                        End If
                    Case NeonLayouts.FrontAndBack
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, False)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = True
                            lastVehMemory.BackNeon = True
                            lastVehMemory.LeftNeon = False
                            lastVehMemory.RightNeon = False
                        End If
                    Case NeonLayouts.FrontAndSides
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = True
                            lastVehMemory.BackNeon = False
                            lastVehMemory.LeftNeon = True
                            lastVehMemory.RightNeon = True
                        End If
                    Case NeonLayouts.BackAndSides
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, False)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = False
                            lastVehMemory.BackNeon = True
                            lastVehMemory.LeftNeon = True
                            lastVehMemory.RightNeon = True
                        End If
                    Case NeonLayouts.FrontBackAndSides
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetNeonLightsOn(VehicleNeonLight.Back, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Front, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Left, True)
                            veh.SetNeonLightsOn(VehicleNeonLight.Right, True)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                            lastVehMemory.FrontNeon = True
                            lastVehMemory.BackNeon = True
                            lastVehMemory.LeftNeon = True
                            lastVehMemory.RightNeon = True
                        End If
                End Select
                PlaySpeech("")
            End If

            'Wheels Mods           
            If (sender Is mSBikeWheels) Or (sender Is mCBikeWheels) Then 'gmBikeWheels
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.FrontWheels, selectedItem.SubInteger1, False)
                    veh.SetMod(VehicleMod.BackWheels, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.WheelType = veh.WheelType
                    lastVehMemory.FrontWheels = selectedItem.SubInteger1
                    lastVehMemory.BackWheels = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_WHEEL")
                End If
            ElseIf (sender Is mSHighEnd) Or (sender Is mSLowrider) Or (sender Is mSMuscle) Or (sender Is mSOffroad) Or (sender Is mSSport) Or (sender Is mSSUV) Or (sender Is mSTuner) Or (sender Is mCHighEnd) Or (sender Is mCLowrider) Or (sender Is mCMuscle) Or (sender Is mCOffroad) Or (sender Is mCSport) Or (sender Is mCSUV) Or (sender Is mCTuner) Or (sender Is mBennysOriginals) Or (sender Is mBespoke) Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SetMod(VehicleMod.FrontWheels, selectedItem.SubInteger1, False)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.WheelType = veh.WheelType
                    lastVehMemory.FrontWheels = selectedItem.SubInteger1
                    PlaySpeech("LR_UPGRADE_WHEEL")
                End If
            End If
            If sender Is mTires Then
                Select Case veh.WheelType
                    Case 8, 9
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            veh.SetMod(VehicleMod.FrontWheels, selectedItem.SubInteger1, False)
                            selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                            lastVehMemory.FrontWheels = selectedItem.SubInteger1
                            selectedItem.SetRightLabel(Nothing)
                            Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                            selectedItem.SubInteger2 = 0
                        End If
                    Case Else
                        If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                            If selectedItem.SubInteger1 = 1 Then
                                veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.FrontWheels), False)
                                If veh.ClassType = VehicleClass.Motorcycles Then veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.BackWheels), False)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                lastVehMemory.WheelsVariation = False
                                selectedItem.SetRightLabel(Nothing)
                                Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                                selectedItem.SubInteger2 = 0
                            ElseIf selectedItem.SubInteger1 = 7 Then
                                veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.FrontWheels), True)
                                If veh.ClassType = VehicleClass.Motorcycles Then veh.SetMod(VehicleMod.FrontWheels, veh.GetMod(VehicleMod.BackWheels), True)
                                selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                                lastVehMemory.WheelsVariation = True
                                selectedItem.SetRightLabel(Nothing)
                                Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                                selectedItem.SubInteger2 = 0
                            End If
                        End If
                End Select
                PlaySpeech("LR_UPGRADE_WHEEL")
            End If

            'Wheel Type
            If sender Is gmWheelType Then
                If selectedItem Is giBikeWheels Then
                    veh.WheelType = VehicleWheelType.BikeWheels
                    ''RefreshModMenuFor(gmBikeWheels, iBikeWheels, VehicleMod.BackWheels)
                    'RefreshStockWheelsModMenuFor(mSBikeWheels, iSBikeWheels, VehicleMod.FrontWheels)
                    'RefreshChromeWheelsModMenuFor(mCBikeWheels, iCBikeWheels, VehicleMod.FrontWheels)
                    RefreshBikeWheelsModMenuFor(mSBikeWheels, iSBikeWheels, VehicleMod.BackWheels, False)
                    RefreshBikeWheelsModMenuFor(mCBikeWheels, iCBikeWheels, VehicleMod.BackWheels, True)
                ElseIf selectedItem Is giHighEndWheels Then
                    veh.WheelType = VehicleWheelType.HighEnd
                    RefreshStockWheelsModMenuFor(mSHighEnd, iSHighEnd, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCHighEnd, iCHighEnd, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giLowriderWheels Then
                    veh.WheelType = VehicleWheelType.Lowrider
                    RefreshStockWheelsModMenuFor(mSLowrider, iSLowrider, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCLowrider, iCLowrider, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giMuscleWheels Then
                    veh.WheelType = VehicleWheelType.Muscle
                    RefreshStockWheelsModMenuFor(mSMuscle, iSMuscle, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCMuscle, iCMuscle, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giOffroadWheels Then
                    veh.WheelType = VehicleWheelType.Offroad
                    RefreshStockWheelsModMenuFor(mSOffroad, iSOffroad, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCOffroad, iCOffroad, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giSportWheels Then
                    veh.WheelType = VehicleWheelType.Sport
                    RefreshStockWheelsModMenuFor(mSSport, iSSport, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCSport, iCSport, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giSUVWheels Then
                    veh.WheelType = VehicleWheelType.SUV
                    RefreshStockWheelsModMenuFor(mSSUV, iSSUV, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCSUV, iCSUV, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giTunerWheels Then
                    veh.WheelType = VehicleWheelType.Tuner
                    RefreshStockWheelsModMenuFor(mSTuner, iSTuner, VehicleMod.FrontWheels)
                    RefreshChromeWheelsModMenuFor(mCTuner, iCTuner, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giBennysWheels Then
                    veh.WheelType = 8
                    RefreshLowriderDLCWheelsModMenuFor(mBennysOriginals, iBennys, VehicleMod.FrontWheels)
                ElseIf selectedItem Is giBespokeWheels Then
                    veh.WheelType = 9
                    RefreshLowriderDLCWheelsModMenuFor(mBespoke, iBespoke, VehicleMod.FrontWheels)
                End If
            End If
            If sender Is gmBikeWheels Then
                veh.WheelType = VehicleWheelType.BikeWheels
            ElseIf sender Is gmHighEnd Then
                veh.WheelType = VehicleWheelType.HighEnd
            ElseIf sender Is gmLowrider Then
                veh.WheelType = VehicleWheelType.Lowrider
            ElseIf sender Is gmMuscle Then
                veh.WheelType = VehicleWheelType.Muscle
            ElseIf sender Is gmOffroad Then
                veh.WheelType = VehicleWheelType.Offroad
            ElseIf sender Is gmSport Then
                veh.WheelType = VehicleWheelType.Sport
            ElseIf sender Is gmSUV Then
                veh.WheelType = VehicleWheelType.SUV
            ElseIf sender Is gmTuner Then
                veh.WheelType = VehicleWheelType.Tuner
            ElseIf sender Is mBennysOriginals Then
                veh.WheelType = 8
            ElseIf sender Is mBespoke Then
                veh.WheelType = 9
            End If

            'Color
            If sender Is mLightsColor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.DashboardColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.LightsColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mTrimColor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.TrimColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.TrimColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mRimColor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.RimColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.RimColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf (sender Is mPrimaryChromeColor) Or (sender Is mPrimaryClassicColor) Or (sender Is mPrimaryMatteColor) Or (sender Is mPrimaryMetalsColor) Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.PrimaryColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.PrimaryColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mPrimaryMetallicColor Then

                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.PrimaryColor = selectedItem.SubInteger1
                    veh.PearlescentColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.PrimaryColor = selectedItem.SubInteger1
                    lastVehMemory.PearlescentColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mPrimaryPearlescentColor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.PearlescentColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.PearlescentColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf (sender Is mSecondaryChromeColor) Or (sender Is mSecondaryClassicColor) Or (sender Is mSecondaryMatteColor) Or (sender Is mSecondaryMetallicColor) Or (sender Is mSecondaryMetalsColor) Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.SecondaryColor = selectedItem.SubInteger1
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger2)
                    selectedItem.SubInteger2 = 0
                    lastVehMemory.SecondaryColor = selectedItem.SubInteger1
                    PlaySpeech("SHOP_SELL_COSMETICS")
                End If
            ElseIf sender Is mNeonColor Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.NeonLightsColor = Drawing.Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger4)
                    selectedItem.SubInteger4 = 0
                    lastVehMemory.NeonLightsColor = Drawing.Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                    PlaySpeech("")
                End If
            ElseIf sender Is mTireSmoke Then
                If selectedItem.RightBadge = UIMenuItem.BadgeStyle.None Then
                    veh.TireSmokeColor = Drawing.Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                    veh.ToggleMod(VehicleToggleMod.TireSmoke, True)
                    selectedItem.SetRightBadge(UIMenuItem.BadgeStyle.Car)
                    selectedItem.SetRightLabel(Nothing)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger4)
                    selectedItem.SubInteger4 = 0
                    lastVehMemory.TireSmokeColor = Drawing.Color.FromArgb(selectedItem.SubInteger1, selectedItem.SubInteger2, selectedItem.SubInteger3)
                    PlaySpeech("")
                End If
            End If

            'Camera
            If sender Is gmBumper Then
                If selectedItem Is giFBumper Then
                    Select Case veh.Model
                        Case "monster3", "monster4", "monster5"
                            camera.MainCameraPosition = CameraPosition.Car
                        Case Else
                            If veh.HasBone("neon_f") Then
                                camera.MainCameraPosition = CameraPosition.FrontBumper
                            Else
                                camera.MainCameraPosition = CameraPosition.Hood
                            End If
                    End Select
                ElseIf selectedItem Is giRBumper Then
                    Select Case veh.Model
                        Case "monster3", "monster4", "monster5"
                            camera.MainCameraPosition = CameraPosition.Car
                        Case Else
                            If veh.HasBone("neon_r") Then
                                Select Case veh.Model
                                    Case "barrage"
                                        camera.MainCameraPosition = CameraPosition.Car
                                    Case Else
                                        camera.MainCameraPosition = CameraPosition.RearBumper
                                End Select
                            Else
                                camera.MainCameraPosition = CameraPosition.Trunk
                            End If
                    End Select
                ElseIf selectedItem Is giSSkirt Then
                    Select Case veh.Model
                        Case "barrage"
                            camera.MainCameraPosition = CameraPosition.Car
                        Case Else
                            camera.MainCameraPosition = CameraPosition.Wheels
                    End Select
                End If
            ElseIf sender Is gmPlate Then
                If selectedItem Is giNumberPlate Then
                    If veh.HasBone("platelight") Then
                        If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                            camera.MainCameraPosition = CameraPosition.Car
                        Else
                            camera.MainCameraPosition = CameraPosition.BackPlate
                        End If
                    ElseIf veh.HasBone("neon_f") Then
                        Select Case veh.Model
                            Case "stromberg", "z190", "comet4", "autarch"
                                camera.MainCameraPosition = CameraPosition.Car
                            Case Else
                                camera.MainCameraPosition = CameraPosition.FrontPlate
                        End Select
                    Else
                        camera.MainCameraPosition = CameraPosition.Car
                    End If
                ElseIf selectedItem Is giPlateHolder Then
                    Select Case veh.Model
                        Case "slamvan3", "buccaneer2", "chino2", "sabregt2", "voodoo", "primo2", "tornado5", "minivan2"
                            camera.MainCameraPosition = CameraPosition.RearBumper
                        Case Else
                            camera.MainCameraPosition = CameraPosition.FrontBumper
                    End Select

                ElseIf selectedItem Is giVanityPlate Then
                    camera.MainCameraPosition = CameraPosition.FrontBumper
                End If
            ElseIf sender Is gmInterior Then
                If selectedItem Is giDoor Then
                    veh.OpenDoor(VehicleDoor.FrontLeftDoor, False, False)
                    veh.OpenDoor(VehicleDoor.FrontRightDoor, False, False)
                End If
            ElseIf sender Is gmBodywork Then
                If ((selectedItem Is giShifter) Or (selectedItem Is giFuelTank) Or (selectedItem Is giOilTank) Or (selectedItem Is giBeltDriveCovers) Or (selectedItem Is giBTank)) Then
                    camera.MainCameraPosition = CameraPosition.Wheels
                ElseIf selectedItem Is giFMudguard Then
                    Select Case veh.Model
                        Case "blazer4"
                            camera.MainCameraPosition = CameraPosition.Engine
                        Case Else
                            camera.MainCameraPosition = CameraPosition.FrontMuguard
                    End Select

                ElseIf selectedItem Is giRMudguard Then
                    camera.MainCameraPosition = CameraPosition.RearMuguard
                End If
            ElseIf sender Is gmEngine Then
                If selectedItem Is giStruts Then
                    Select Case veh.Model
                        Case "comet3"
                            veh.OpenDoor(VehicleDoor.Trunk, False, False)
                            camera.MainCameraPosition = CameraPosition.FrontBumper
                    End Select
                End If
            ElseIf sender Is gmBodyworkArena Then
                If selectedItem Is giOrnaments Then
                    camera.MainCameraPosition = CameraPosition.Interior
                End If
            ElseIf sender Is gmWeapon Then
                If selectedItem Is giArchCover Then
                    Select Case veh.Model
                        Case "monster3", "monster4", "monster5"
                            camera.MainCameraPosition = CameraPosition.Car
                        Case Else
                            camera.MainCameraPosition = CameraPosition.FrontBumper
                    End Select
                ElseIf selectedItem Is giTank Then
                    HoodCamera(False)
                ElseIf selectedItem Is giRoof Then
                    If veh.HasBone("boot") Then
                        If veh.GetVehTrunkPos = EngineLoc.rear Then
                            camera.MainCameraPosition = CameraPosition.Trunk
                        Else
                            If veh.HasBone("windscreen_r") Then
                                camera.MainCameraPosition = CameraPosition.RearWindscreen
                            Else
                                camera.MainCameraPosition = CameraPosition.RearEngine
                            End If
                        End If
                    ElseIf veh.HasBone("windscreen_r") Then
                        camera.MainCameraPosition = CameraPosition.RearWindscreen
                    ElseIf veh.GetVehEnginePos = EngineLoc.rear Then
                        Select Case veh.Model
                            Case "barrage"
                                camera.MainCameraPosition = CameraPosition.Car
                            Case Else
                                camera.MainCameraPosition = CameraPosition.RearEngine
                        End Select
                    ElseIf veh.HasBone("neon_b") Then
                        camera.MainCameraPosition = CameraPosition.RearBumper
                    Else
                        camera.MainCameraPosition = CameraPosition.Car
                    End If
                End If
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MainMenuItemSelectHandler(sender As UIMenu, selectedItem As UIMenuItem, index As Integer)
        Try
            If sender Is MainMenu Then
                If selectedItem Is iRepair Then
                    isRepairing = True
                    veh.Repair()
                    veh.Wash()
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger1)
                    RefreshMenus()
                ElseIf selectedItem Is iUpgrade Then
                    Game.FadeScreenOut(1000)
                    Script.Wait(1000)
                    Dim vehUp As Vehicle = World.CreateVehicle(LowriderUpgrade(veh.Model), veh.Position, veh.Heading)
                    vehUp.IsPersistent = False
                    vehUp.PrimaryColor = lastVehMemory.PrimaryColor
                    vehUp.SecondaryColor = lastVehMemory.SecondaryColor
                    vehUp.DashboardColor = lastVehMemory.LightsColor
                    vehUp.PearlescentColor = lastVehMemory.PearlescentColor
                    vehUp.TrimColor = lastVehMemory.TrimColor
                    vehUp.RimColor = lastVehMemory.RimColor
                    vehUp.NeonLightsColor = lastVehMemory.NeonLightsColor
                    vehUp.TireSmokeColor = lastVehMemory.TireSmokeColor
                    vehUp.InstallModKit()
                    vehUp.WheelType = lastVehMemory.WheelType
                    vehUp.SetMod(VehicleMod.Aerials, lastVehMemory.Aerials, False)
                    vehUp.SetMod(VehicleMod.AirFilter, lastVehMemory.AirFilter, False)
                    vehUp.SetMod(VehicleMod.ArchCover, lastVehMemory.ArchCover, False)
                    vehUp.SetMod(VehicleMod.Armor, lastVehMemory.Armor, False)
                    vehUp.SetMod(VehicleMod.BackWheels, lastVehMemory.BackWheels, False)
                    vehUp.SetMod(VehicleMod.Brakes, lastVehMemory.Brakes, False)
                    vehUp.SetMod(VehicleMod.ColumnShifterLevers, lastVehMemory.ColumnShifterLevers, False)
                    vehUp.SetMod(VehicleMod.Dashboard, lastVehMemory.Dashboard, False)
                    vehUp.SetMod(VehicleMod.DialDesign, lastVehMemory.DialDesign, False)
                    vehUp.SetMod(VehicleMod.DoorSpeakers, lastVehMemory.DoorSpeakers, False)
                    vehUp.SetMod(VehicleMod.Engine, lastVehMemory.Engine, False)
                    vehUp.SetMod(VehicleMod.EngineBlock, lastVehMemory.EngineBlock, False)
                    vehUp.SetMod(VehicleMod.Exhaust, lastVehMemory.Exhaust, False)
                    vehUp.SetMod(VehicleMod.Fender, lastVehMemory.Fender, False)
                    vehUp.SetMod(VehicleMod.Frame, lastVehMemory.Frame, False)
                    vehUp.SetMod(VehicleMod.FrontBumper, lastVehMemory.FrontBumper, False)
                    vehUp.SetMod(VehicleMod.FrontWheels, lastVehMemory.FrontWheels, False)
                    vehUp.SetMod(VehicleMod.Grille, lastVehMemory.Grille, False)
                    vehUp.SetMod(VehicleMod.Hood, lastVehMemory.Hood, False)
                    vehUp.SetMod(VehicleMod.Horns, lastVehMemory.Horns, False)
                    vehUp.SetMod(VehicleMod.Hydraulics, lastVehMemory.Hydraulics, False)
                    vehUp.SetMod(VehicleMod.Livery, lastVehMemory.Livery, False)
                    vehUp.SetLivery2(lastVehMemory.Livery2)
                    vehUp.SetMod(VehicleMod.Ornaments, lastVehMemory.Ornaments, False)
                    vehUp.SetMod(VehicleMod.Plaques, lastVehMemory.Plaques, False)
                    vehUp.SetMod(VehicleMod.PlateHolder, lastVehMemory.PlateHolder, False)
                    vehUp.SetMod(VehicleMod.RearBumper, lastVehMemory.RearBumper, False)
                    vehUp.SetMod(VehicleMod.RightFender, lastVehMemory.RightFender, False)
                    vehUp.SetMod(VehicleMod.Roof, lastVehMemory.Roof, False)
                    vehUp.SetMod(VehicleMod.Seats, lastVehMemory.Seats, False)
                    vehUp.SetMod(VehicleMod.SideSkirt, lastVehMemory.SideSkirt, False)
                    vehUp.SetMod(VehicleMod.Speakers, lastVehMemory.Speakers, False)
                    vehUp.SetMod(VehicleMod.Spoilers, lastVehMemory.Spoilers, False)
                    vehUp.SetMod(VehicleMod.SteeringWheels, lastVehMemory.SteeringWheels, False)
                    vehUp.SetMod(VehicleMod.Struts, lastVehMemory.Struts, False)
                    vehUp.SetMod(VehicleMod.Suspension, lastVehMemory.Suspension, False)
                    vehUp.SetMod(VehicleMod.Tank, lastVehMemory.Tank, False)
                    vehUp.SetMod(VehicleMod.Transmission, lastVehMemory.Transmission, False)
                    vehUp.SetMod(VehicleMod.Trim, lastVehMemory.Trim, False)
                    vehUp.SetMod(VehicleMod.TrimDesign, lastVehMemory.TrimDesign, False)
                    vehUp.SetMod(VehicleMod.Trunk, lastVehMemory.Trunk, False)
                    vehUp.SetMod(VehicleMod.VanityPlates, lastVehMemory.VanityPlates, False)
                    vehUp.SetMod(VehicleMod.Windows, lastVehMemory.Windows, False)
                    vehUp.ToggleMod(VehicleToggleMod.TireSmoke, True)
                    vehUp.ToggleMod(VehicleToggleMod.Turbo, lastVehMemory.Turbo)
                    vehUp.ToggleMod(VehicleToggleMod.XenonHeadlights, lastVehMemory.Headlights)
                    vehUp.SetXenonHeadlightsColor(lastVehMemory.HeadlightsColor, vehUp.IsToggleModOn(VehicleToggleMod.XenonHeadlights))
                    vehUp.NumberPlateType = lastVehMemory.NumberPlate
                    vehUp.NumberPlate = lastVehMemory.PlateNumbers
                    vehUp.CanTiresBurst = lastVehMemory.BulletProofTires
                    If IsNitroModInstalled() Then vehUp.SetBool(nitroMod, lastVehMemory.Nitro)
                    veh.Delete()
                    ply.Task.WarpIntoVehicle(veh, VehicleSeat.Driver)
                    veh = vehUp
                    veh.InstallModKit()
                    MainMenu.MenuItems.Remove(selectedItem)
                    isRepairing = True
                    RefreshMenus()
                    camera.RepositionFor(veh)
                    Script.Wait(1000)
                    Game.FadeScreenIn(1000)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger1)
                    Native.Function.Call(Hash._START_SCREEN_EFFECT, "MP_corona_switch_supermod", 0, 1)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lowrider_Upgrade", "Lowrider_Super_Mod_Garage_Sounds", 1)
                    PlaySpeech("LR_UPGRADE_SUPERMOD")
                ElseIf selectedItem Is iUpgradeMod Then
                    Game.FadeScreenOut(1000)
                    Script.Wait(1000)
                    Dim upgrade2 As Tuple(Of String, Integer) = veh.DisplayName.GetUpgradeModVehicleInfo
                    Dim vehUp As Vehicle = World.CreateVehicle(upgrade2.Item1, veh.Position, veh.Heading)
                    vehUp.IsPersistent = False
                    vehUp.PrimaryColor = lastVehMemory.PrimaryColor
                    vehUp.SecondaryColor = lastVehMemory.SecondaryColor
                    vehUp.DashboardColor = lastVehMemory.LightsColor
                    vehUp.PearlescentColor = lastVehMemory.PearlescentColor
                    vehUp.TrimColor = lastVehMemory.TrimColor
                    vehUp.RimColor = lastVehMemory.RimColor
                    vehUp.NeonLightsColor = lastVehMemory.NeonLightsColor
                    vehUp.TireSmokeColor = lastVehMemory.TireSmokeColor
                    vehUp.InstallModKit()
                    vehUp.WheelType = lastVehMemory.WheelType
                    vehUp.SetMod(VehicleMod.Aerials, lastVehMemory.Aerials, False)
                    vehUp.SetMod(VehicleMod.AirFilter, lastVehMemory.AirFilter, False)
                    vehUp.SetMod(VehicleMod.ArchCover, lastVehMemory.ArchCover, False)
                    vehUp.SetMod(VehicleMod.Armor, lastVehMemory.Armor, False)
                    vehUp.SetMod(VehicleMod.BackWheels, lastVehMemory.BackWheels, False)
                    vehUp.SetMod(VehicleMod.Brakes, lastVehMemory.Brakes, False)
                    vehUp.SetMod(VehicleMod.ColumnShifterLevers, lastVehMemory.ColumnShifterLevers, False)
                    vehUp.SetMod(VehicleMod.Dashboard, lastVehMemory.Dashboard, False)
                    vehUp.SetMod(VehicleMod.DialDesign, lastVehMemory.DialDesign, False)
                    vehUp.SetMod(VehicleMod.DoorSpeakers, lastVehMemory.DoorSpeakers, False)
                    vehUp.SetMod(VehicleMod.Engine, lastVehMemory.Engine, False)
                    vehUp.SetMod(VehicleMod.EngineBlock, lastVehMemory.EngineBlock, False)
                    vehUp.SetMod(VehicleMod.Exhaust, lastVehMemory.Exhaust, False)
                    vehUp.SetMod(VehicleMod.Fender, lastVehMemory.Fender, False)
                    vehUp.SetMod(VehicleMod.Frame, lastVehMemory.Frame, False)
                    vehUp.SetMod(VehicleMod.FrontBumper, lastVehMemory.FrontBumper, False)
                    vehUp.SetMod(VehicleMod.FrontWheels, lastVehMemory.FrontWheels, False)
                    vehUp.SetMod(VehicleMod.Grille, lastVehMemory.Grille, False)
                    vehUp.SetMod(VehicleMod.Hood, lastVehMemory.Hood, False)
                    vehUp.SetMod(VehicleMod.Horns, lastVehMemory.Horns, False)
                    vehUp.SetMod(VehicleMod.Hydraulics, lastVehMemory.Hydraulics, False)
                    vehUp.SetMod(VehicleMod.Livery, lastVehMemory.Livery, False)
                    vehUp.SetLivery2(lastVehMemory.Livery2)
                    vehUp.SetMod(VehicleMod.Ornaments, lastVehMemory.Ornaments, False)
                    vehUp.SetMod(VehicleMod.Plaques, lastVehMemory.Plaques, False)
                    vehUp.SetMod(VehicleMod.PlateHolder, lastVehMemory.PlateHolder, False)
                    vehUp.SetMod(VehicleMod.RearBumper, lastVehMemory.RearBumper, False)
                    vehUp.SetMod(VehicleMod.RightFender, lastVehMemory.RightFender, False)
                    vehUp.SetMod(VehicleMod.Roof, lastVehMemory.Roof, False)
                    vehUp.SetMod(VehicleMod.Seats, lastVehMemory.Seats, False)
                    vehUp.SetMod(VehicleMod.SideSkirt, lastVehMemory.SideSkirt, False)
                    vehUp.SetMod(VehicleMod.Speakers, lastVehMemory.Speakers, False)
                    vehUp.SetMod(VehicleMod.Spoilers, lastVehMemory.Spoilers, False)
                    vehUp.SetMod(VehicleMod.SteeringWheels, lastVehMemory.SteeringWheels, False)
                    vehUp.SetMod(VehicleMod.Struts, lastVehMemory.Struts, False)
                    vehUp.SetMod(VehicleMod.Suspension, lastVehMemory.Suspension, False)
                    vehUp.SetMod(VehicleMod.Tank, lastVehMemory.Tank, False)
                    vehUp.SetMod(VehicleMod.Transmission, lastVehMemory.Transmission, False)
                    vehUp.SetMod(VehicleMod.Trim, lastVehMemory.Trim, False)
                    vehUp.SetMod(VehicleMod.TrimDesign, lastVehMemory.TrimDesign, False)
                    vehUp.SetMod(VehicleMod.Trunk, lastVehMemory.Trunk, False)
                    vehUp.SetMod(VehicleMod.VanityPlates, lastVehMemory.VanityPlates, False)
                    vehUp.SetMod(VehicleMod.Windows, lastVehMemory.Windows, False)
                    vehUp.ToggleMod(VehicleToggleMod.TireSmoke, True)
                    vehUp.ToggleMod(VehicleToggleMod.Turbo, lastVehMemory.Turbo)
                    vehUp.ToggleMod(VehicleToggleMod.XenonHeadlights, lastVehMemory.Headlights)
                    vehUp.SetXenonHeadlightsColor(lastVehMemory.HeadlightsColor, vehUp.IsToggleModOn(VehicleToggleMod.XenonHeadlights))
                    vehUp.NumberPlateType = lastVehMemory.NumberPlate
                    vehUp.NumberPlate = lastVehMemory.PlateNumbers
                    vehUp.CanTiresBurst = lastVehMemory.BulletProofTires
                    If IsNitroModInstalled() Then vehUp.SetBool(nitroMod, lastVehMemory.Nitro)
                    veh.Delete()
                    ply.Task.WarpIntoVehicle(veh, VehicleSeat.Driver)
                    veh = veh
                    veh.InstallModKit()
                    MainMenu.MenuItems.Remove(selectedItem)
                    isRepairing = True
                    RefreshMenus()
                    camera.RepositionFor(veh)
                    Script.Wait(1000)
                    Game.FadeScreenIn(1000)
                    Game.Player.Money = (Game.Player.Money - selectedItem.SubInteger1)
                    Native.Function.Call(Hash._START_SCREEN_EFFECT, "MP_corona_switch_supermod", 0, 1)
                    Native.Function.Call(Hash.PLAY_SOUND_FRONTEND, -1, "Lowrider_Upgrade", "Lowrider_Super_Mod_Garage_Sounds", 1)
                    PlaySpeech("LR_UPGRADE_SUPERMOD")
                ElseIf selectedItem Is iUpgradeAW Then
                    Dim sitem = mUpgradeAW.MenuItems.First
                    arenaVehImage = sitem.SubString2
                ElseIf selectedItem Is giEngine Then
                    Select Case veh.Model
                        Case "alpha"
                            veh.OpenDoor(VehicleDoor.Hood, False, False)
                            camera.MainCameraPosition = CameraPosition.Hood
                        Case Else
                            If Not veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                                HoodCamera(True)
                            Else
                                camera.MainCameraPosition = CameraPosition.Wheels
                            End If
                    End Select
                ElseIf selectedItem Is giInterior Then
                    If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                        camera.MainCameraPosition = CameraPosition.Car
                    Else
                        camera.MainCameraPosition = CameraPosition.Interior
                    End If
                ElseIf selectedItem Is giWheels Then
                    camera.MainCameraPosition = CameraPosition.Wheels
                ElseIf selectedItem Is giLights Then
                    veh.HighBeamsOn = True
                    veh.LightsOn = True
                ElseIf selectedItem Is giExhaust Then
                    Select Case veh.Model
                        Case "sultanrs", "guardian", "ratloader", "ratloader2", "banshee", "mamba", "feltzer3", "le7b", "barrage"
                            camera.MainCameraPosition = CameraPosition.Wheels
                        Case "police3"
                            camera.MainCameraPosition = CameraPosition.Trunk
                        Case "tornado6"
                            camera.MainCameraPosition = CameraPosition.Engine
                        Case Else
                            If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                                camera.MainCameraPosition = CameraPosition.BikeExhaust
                            Else
                                camera.MainCameraPosition = CameraPosition.Exhaust 'CameraPosition.RearBumper
                            End If
                    End Select
                ElseIf selectedItem Is giBrakes Then
                    camera.MainCameraPosition = CameraPosition.Wheels
                ElseIf selectedItem Is giGrille Then
                    Select Case veh.Model
                        Case "penetrator", "torero", "viseris"
                            camera.MainCameraPosition = CameraPosition.RearEngine
                        Case "banshee2"
                            camera.MainCameraPosition = CameraPosition.Trunk
                        Case "zr3802"
                            camera.MainCameraPosition = CameraPosition.Car
                        Case Else
                            camera.MainCameraPosition = CameraPosition.Grille
                    End Select
                ElseIf selectedItem Is giHood Then
                    HoodCamera(False)
                ElseIf selectedItem Is giHydraulics Then
                    veh.OpenDoor(VehicleDoor.Trunk, False, False)
                    camera.MainCameraPosition = CameraPosition.Trunk
                ElseIf selectedItem Is giTrunk Then
                    veh.OpenDoor(VehicleDoor.Trunk, False, False)
                    camera.MainCameraPosition = CameraPosition.Trunk
                ElseIf selectedItem Is giPlaques Then
                    camera.MainCameraPosition = CameraPosition.Plaque
                ElseIf selectedItem Is giSpoilers Then
                    If veh.HasBone("boot") Then
                        If veh.GetVehTrunkPos = EngineLoc.rear Then
                            camera.MainCameraPosition = CameraPosition.Trunk
                        Else
                            If veh.HasBone("windscreen_r") Then
                                camera.MainCameraPosition = CameraPosition.RearWindscreen
                            Else
                                camera.MainCameraPosition = CameraPosition.RearEngine
                            End If
                        End If
                    ElseIf veh.HasBone("windscreen_r") Then
                        camera.MainCameraPosition = CameraPosition.RearWindscreen
                    ElseIf veh.GetVehEnginePos = EngineLoc.rear Then
                        Select Case veh.Model
                            Case "barrage"
                                camera.MainCameraPosition = CameraPosition.Car
                            Case Else
                                camera.MainCameraPosition = CameraPosition.RearEngine
                        End Select
                    ElseIf veh.HasBone("neon_b") Then
                        camera.MainCameraPosition = CameraPosition.RearBumper
                    Else
                        camera.MainCameraPosition = CameraPosition.Car
                    End If
                ElseIf selectedItem Is giTank Then
                    Select Case veh.Model
                        Case "slamvan3"
                            camera.MainCameraPosition = CameraPosition.Trunk
                        Case "elegy"
                            camera.MainCameraPosition = CameraPosition.FrontPlate
                        Case Else
                            camera.MainCameraPosition = CameraPosition.Tank
                    End Select
                ElseIf (selectedItem Is giAirfilter) Or (selectedItem Is giStruts) Then
                    Select Case veh.Model
                        Case "zr380", "zr3802", "zr3803", "issi4", "issi5", "issi6"
                            camera.MainCameraPosition = CameraPosition.Boost
                        Case "bruiser", "bruiser2", "bruiser3", "cerberus", "cerberus2", "cerberus3", "deathbike", "deathbike2", "deathbike3", "dominator4", "dominator5", "dominator6",
                             "impaler2", "impaler3", "impaler4", "imperator", "imperator2", "imperator3", "monster3", "monster4", "monster5", "slamvan4", "slamvan5", "slamvan6",
                             "brutus", "brutus2", "brutus3", "scarab", "scarab2", "scarab3"
                            HoodCamera(False)
                        Case Else
                            HoodCamera(True)
                    End Select
                ElseIf selectedItem Is giNumberPlate Then
                    If veh.HasBone("platelight") Then
                        If veh.ClassType = VehicleClass.Motorcycles Or veh.Model = "blazer4" Then
                            camera.MainCameraPosition = CameraPosition.Car
                        Else
                            camera.MainCameraPosition = CameraPosition.BackPlate
                        End If
                    ElseIf veh.HasBone("neon_f") Then
                        Select Case veh.Model
                            Case "stromberg", "z190", "comet4", "autarch"
                                camera.MainCameraPosition = CameraPosition.Car
                            Case Else
                                camera.MainCameraPosition = CameraPosition.FrontPlate
                        End Select
                    Else
                        camera.MainCameraPosition = CameraPosition.Car
                    End If
                End If
            ElseIf sender Is QuitMenu Then
                QuitMenu.Visible = False
                PlayExitCutScene()
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub MainMenuCloseHandler(sender As UIMenu)
        Try
            If sender Is QuitMenu Then
                MainMenu.Visible = True
            ElseIf sender Is MainMenu Then
                QuitMenu.Visible = True
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub

    Public Sub ModsMenuCloseHandler(sender As UIMenu)
        Try
            'Performance Mods
            veh.SetMod(VehicleMod.Suspension, lastVehMemory.Suspension, False)
            veh.SetMod(VehicleMod.Armor, lastVehMemory.Armor, False)
            veh.SetMod(VehicleMod.Brakes, lastVehMemory.Brakes, False)
            veh.SetMod(VehicleMod.Transmission, lastVehMemory.Transmission, False)
            veh.SetMod(VehicleMod.Engine, lastVehMemory.Engine, False)
            If IsNitroModInstalled() Then veh.SetBool(nitroMod, lastVehMemory.Nitro)

            'Mods
            veh.SetMod(VehicleMod.FrontBumper, lastVehMemory.FrontBumper, False)
            veh.SetMod(VehicleMod.RearBumper, lastVehMemory.RearBumper, False)
            veh.SetMod(VehicleMod.SideSkirt, lastVehMemory.SideSkirt, False)
            veh.NumberPlateType = lastVehMemory.NumberPlate
            veh.WheelType = lastVehMemory.WheelType
            veh.SetMod(VehicleMod.FrontWheels, lastVehMemory.FrontWheels, lastVehMemory.WheelsVariation)
            veh.SetMod(VehicleMod.BackWheels, lastVehMemory.BackWheels, lastVehMemory.WheelsVariation)
            veh.ToggleMod(VehicleToggleMod.XenonHeadlights, lastVehMemory.Headlights)
            veh.SetXenonHeadlightsColor(lastVehMemory.HeadlightsColor, veh.IsToggleModOn(VehicleToggleMod.XenonHeadlights))
            veh.SetNeonLightsOn(VehicleNeonLight.Back, lastVehMemory.BackNeon)
            veh.SetNeonLightsOn(VehicleNeonLight.Front, lastVehMemory.FrontNeon)
            veh.SetNeonLightsOn(VehicleNeonLight.Left, lastVehMemory.LeftNeon)
            veh.SetNeonLightsOn(VehicleNeonLight.Right, lastVehMemory.RightNeon)
            veh.SetMod(VehicleMod.ArchCover, lastVehMemory.ArchCover, False)
            veh.SetMod(VehicleMod.Exhaust, lastVehMemory.Exhaust, False)
            veh.SetMod(VehicleMod.Fender, lastVehMemory.Fender, False)
            veh.SetMod(VehicleMod.RightFender, lastVehMemory.RightFender, False)
            veh.SetMod(VehicleMod.DoorSpeakers, lastVehMemory.DoorSpeakers, False)
            veh.SetMod(VehicleMod.Frame, lastVehMemory.Frame, False)
            veh.SetMod(VehicleMod.Grille, lastVehMemory.Grille, False)
            veh.SetMod(VehicleMod.Hood, lastVehMemory.Hood, False)
            veh.SetMod(VehicleMod.Horns, lastVehMemory.Horns, False)
            veh.SetMod(VehicleMod.Hydraulics, lastVehMemory.Hydraulics, False)
            veh.SetMod(VehicleMod.Livery, lastVehMemory.Livery, False)
            veh.SetLivery2(lastVehMemory.Livery2)
            veh.SetMod(VehicleMod.Plaques, lastVehMemory.Plaques, False)
            veh.SetMod(VehicleMod.Roof, lastVehMemory.Roof, False)
            veh.SetMod(VehicleMod.Speakers, lastVehMemory.Speakers, False)
            veh.SetMod(VehicleMod.Spoilers, lastVehMemory.Spoilers, False)
            veh.SetMod(VehicleMod.Aerials, lastVehMemory.Aerials, False)
            veh.SetMod(VehicleMod.Trim, lastVehMemory.Trim, False)
            veh.SetMod(VehicleMod.EngineBlock, lastVehMemory.EngineBlock, False)
            veh.SetMod(VehicleMod.AirFilter, lastVehMemory.AirFilter, False)
            veh.SetMod(VehicleMod.Struts, lastVehMemory.Struts, False)
            veh.SetMod(VehicleMod.ColumnShifterLevers, lastVehMemory.ColumnShifterLevers, False)
            veh.SetMod(VehicleMod.Dashboard, lastVehMemory.Dashboard, False)
            veh.SetMod(VehicleMod.DialDesign, lastVehMemory.DialDesign, False)
            veh.SetMod(VehicleMod.Ornaments, lastVehMemory.Ornaments, False)
            veh.SetMod(VehicleMod.Seats, lastVehMemory.Seats, False)
            veh.SetMod(VehicleMod.SteeringWheels, lastVehMemory.SteeringWheels, False)
            veh.SetMod(VehicleMod.TrimDesign, lastVehMemory.TrimDesign, False)
            veh.SetMod(VehicleMod.PlateHolder, lastVehMemory.PlateHolder, False)
            veh.SetMod(VehicleMod.VanityPlates, lastVehMemory.VanityPlates, False)
            veh.SetMod(VehicleMod.Tank, lastVehMemory.Tank, False)
            veh.SetMod(VehicleMod.Trunk, lastVehMemory.Trunk, False)
            veh.SetMod(VehicleMod.Windows, lastVehMemory.Windows, False)
            veh.ToggleMod(VehicleToggleMod.Turbo, lastVehMemory.Turbo)
            veh.WindowTint = lastVehMemory.Tint
            veh.CanTiresBurst = lastVehMemory.BulletProofTires

            'Color
            veh.DashboardColor = lastVehMemory.LightsColor
            veh.TrimColor = lastVehMemory.TrimColor
            veh.PrimaryColor = lastVehMemory.PrimaryColor
            veh.SecondaryColor = lastVehMemory.SecondaryColor
            veh.PearlescentColor = lastVehMemory.PearlescentColor
            veh.RimColor = lastVehMemory.RimColor
            veh.NeonLightsColor = lastVehMemory.NeonLightsColor
            veh.TireSmokeColor = lastVehMemory.TireSmokeColor

            'Close Doors
            If sender Is gmEngine Then
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, veh, False)
            End If
            If sender Is mStruts Then
                Select Case veh.Model
                    Case "comet3"
                        veh.CloseDoor(VehicleDoor.Trunk, False)
                        camera.MainCameraPosition = CameraPosition.RearBumper
                End Select
            End If
            If sender Is mDoor Then
                Native.Function.Call(Hash.SET_VEHICLE_DOORS_SHUT, veh, False)
            End If
            If sender Is mHydraulics Then veh.CloseDoor(VehicleDoor.Trunk, False)
            If sender Is mTrunk Then veh.CloseDoor(VehicleDoor.Trunk, False)
            If sender Is gmLights Then
                veh.LightsOn = True
                veh.HighBeamsOn = False
            End If
            If sender Is mHorn Then ply.Task.WarpIntoVehicle(veh, VehicleSeat.Driver)

            'Reset Camera Position
            If (sender Is gmInterior) Or (sender Is gmEngine) Or (sender Is mFBumper) Or (sender Is mRBumper) Or (sender Is mSSkirt) Or (sender Is mNumberPlate) Or (sender Is mPlateHolder) Or (sender Is mSpoilers) Or
                (sender Is mVanityPlates) Or (sender Is gmWheels) Or (sender Is mExhaust) Or (sender Is mBrakes) Or (sender Is mGrille) Or (sender Is mHood) Or (sender Is mHydraulics) Or (sender Is mPlaques) Or
                (sender Is mTank) Or (sender Is mShifter) Or (sender Is mFMudguard) Or (sender Is mOilTank) Or (sender Is mRMudguard) Or (sender Is mFuelTank) Or (sender Is mBeltDriveCovers) Or (sender Is mBTank) Or
                (sender Is mTrunk) Or (sender Is mArchCover) Or (sender Is mRoof) Then
                camera.MainCameraPosition = CameraPosition.Car
            End If
            If Not sender.ParentMenu Is gmEngine Then
                If (sender Is mStruts) Or (sender Is mAirFilter) Then
                    camera.MainCameraPosition = CameraPosition.Car
                End If
            End If
            If Not sender.ParentMenu Is gmInterior Then
                If sender Is mOrnaments Then
                    camera.MainCameraPosition = CameraPosition.Car
                End If
            End If
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try
    End Sub
#End Region

    <Extension>
    Public Function NewUIMenu(ByRef menu As UIMenu, gxt As String, gxtUpper As Boolean, showStats As Boolean, Optional closeHandler As MenuCloseEvent = Nothing, Optional selectHandler As ItemSelectEvent = Nothing,
                              Optional indexChangeHandler As IndexChangedEvent = Nothing, Optional itemName As String = "Nothing", Optional itemDesc As String = Nothing) As UIMenu
        Return menu.NewUIMenu(If(gxtUpper, Game.GetGXTEntry(gxt).ToUpper, Game.GetGXTEntry(gxt)), showStats, closeHandler, selectHandler, indexChangeHandler, itemName, itemDesc)
    End Function

    <Extension>
    Public Function NewUIMenu(ByRef menu As UIMenu, title As String, showStats As Boolean, Optional closeHandler As MenuCloseEvent = Nothing, Optional selectHandler As ItemSelectEvent = Nothing,
                              Optional indexChangeHandler As IndexChangedEvent = Nothing, Optional itemName As String = "Nothing", Optional itemDesc As String = Nothing) As UIMenu
        Try
            menu = New UIMenu("", title, showStats)
            menu.SetBannerType(New Sprite("shopui_title_clubhousemod", "shopui_title_clubhousemod", Nothing, Nothing))
            menu.MouseEdgeEnabled = False
            menu.AddInstructionalButton(BtnZoom)
            menu.AddInstructionalButton(BtnZoomOut)
            menu.AddInstructionalButton(BtnFirstPerson)
            _menuPool.Add(menu)
            menu.AddItem(New UIMenuItem(itemName, itemDesc))
            menu.RefreshIndex()
            If Not closeHandler = Nothing Then AddHandler menu.OnMenuClose, closeHandler
            If Not selectHandler = Nothing Then AddHandler menu.OnItemSelect, selectHandler
            If Not indexChangeHandler = Nothing Then AddHandler menu.OnIndexChange, indexChangeHandler
        Catch ex As Exception
            Logger.Log(ex.Message & " " & ex.StackTrace)
        End Try

        Return menu
    End Function

End Module
