﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationKeys
{
    public enum Keys
    {
        HelmetWelcome = 0,
        HelmetFailed = 1,
        Sleep = 2,
        Day = 3,
        Views = 4,
        Quota = 5,
        Money = 6,
        Empty = 7,
        Save = 8,
        DivingBellNotReadyMissingPlayersState = 9,
        DivingBellNotReadyDoorOpenState = 10,
        DivingBellReady = 11,
        DivingBellReadySurface = 12,
        DivingBellRechargingState = 13,
        JoinRandom = 14,
        EnterDiveBellDay2Objective = 15,
        EnterDiveBellObjective = 16,
        BuyEquipmentObjective = 17,
        ExtractVideoObjective = 18,
        FilmSomethingScaryObjective = 19,
        GoToBedFailedObjective = 20,
        GoToBedSuccessObjective = 21,
        InviteFriendsObjective = 22,
        LeaveHouseObjective = 23,
        PickupDiscObjective = 24,
        PickupTheCameraObjective = 25,
        ReturnToTheDiveBellObjective = 26,
        UploadVideoObjective = 27,
        WakeUpObjective = 28,
        CelebrateObjective = 29,
        DaysLeft = 30,
        LastDay = 31,
        Buy = 32,
        Left = 33,
        Right = 34,
        NotSleepy = 35,
        StartGame = 36,
        Submerge = 37,
        ReturnToSurface = 38,
        TerminalBusy = 39,
        Help = 40,
        InviteFriends = 41,
        Open = 42,
        Close = 43,
        GameFull = 44,
        GameStarted = 45,
        Offline = 46,
        StartGameTitle = 47,
        StartGameBody = 48,
        StartGameConfirm = 49,
        Cancel = 50,
        PickUp = 51,
        SwitchCategory = 52,
        AddToCart = 53,
        SoldOut = 54,
        Clear = 55,
        Order = 56,
        DeleteSave = 57,
        DeleteSaveConfirm = 58,
        Yes = 59,
        No = 60,
        Interact = 61,
        HelmetDaysLeft = 62,
        HelmetLastDay = 63,
        HelmetForgetCamera = 64,
        Oxygen = 65,
        Distance = 66,
        Items = 67,
        CloseVideo = 68,
        ReplayVideo = 69,
        SaveVideo = 70,
        UploadToSpookTube = 71,
        ShopClosed = 72,
        Lights = 73,
        Medical = 74,
        Gadgets = 75,
        Emotes = 76,
        Emotes2 = 77,
        Upgrades = 78,
        Misc = 79,
        SpookTubeViews = 80,
        AdRevenue = 81,
        HospitalBill = 82,
        CalibrationUseVoice = 83,
        CalibrationUseHeadphones = 84,
        CalibrationSelectMic = 85,
        CalibrationSelectVoice = 86,
        CalibrationBrightness = 87,
        CalibrationMonster = 88,
        Brightness = 89,
        Continue = 90,
        OldVersion = 91,
        PleaseUpdate = 92,
        CloseGame = 93,
        CrouchKeybindSetting = 94,
        DropKeybindSetting = 95,
        EmoteKeybindSetting = 96,
        InteractKeybindSetting = 97,
        JumpKeybindSetting = 98,
        ToggleSelfieModeKeybindSetting = 99,
        WalkBackwardKeybindSetting = 100,
        WalkForwardKeybindSetting = 101,
        WalkLeftKeybindSetting = 102,
        WalkRightKeybindSetting = 103,
        AmbientOcclusionSetting = 104,
        BrightnessSetting = 105,
        ChromaticAberrationSetting = 106,
        FullscreenSetting = 107,
        VoiceVolumeSetting = 108,
        VoiceSetting = 109,
        VoiceChatModeSetting = 110,
        VSyncSetting = 111,
        ShadowQualitySetting = 112,
        ScreenResolutionSetting = 113,
        SFXVolumeSetting = 114,
        MouseSensitivitySetting = 115,
        MaxFramerateSetting = 116,
        MasterVolumeSetting = 117,
        SprintKeybindSetting = 118,
        JoinError = 119,
        JoinErrorMismatch = 120,
        Ok = 121,
        VideoSaved = 122,
        VideoSavedAs = 123,
        VideoFailedSave = 124,
        ServerIssues = 125,
        DropItem = 126,
        Battery = 127,
        FilmLeft = 128,
        ToggleLight = 129,
        ZoomKey = 130,
        SelfieMode = 131,
        Aim = 132,
        HostingGame = 133,
        Connecting = 134,
        BoomMic = 135,
        Camera = 136,
        CameraBroken = 137,
        Clapper = 138,
        Defibrilator = 139,
        Disc = 140,
        Flare = 141,
        GooBall = 142,
        Hugger = 143,
        LongFlashlightPro = 144,
        LongFlashlight = 145,
        ModernFlashlightPro = 146,
        ModernFlashlight = 147,
        OldFlashlight = 148,
        PartyPopper = 149,
        ShockStick = 150,
        SoundPlayer = 151,
        WalkieTalkie = 152,
        WideFlashlight2 = 153,
        WideFlashlight3 = 154,
        Winch = 155,
        Aminalstateu = 156,
        Animalstatue = 157,
        Bone = 158,
        Brainonastick = 159,
        Chorby = 160,
        Container = 161,
        OldPainting = 162,
        Radio = 163,
        Ribcage = 164,
        Skull = 165,
        Spine = 166,
        ReporterMic = 167,
        RescueHook = 168,
        Emote_Applause = 169,
        Emote_Dance1 = 170,
        Emote_Dance2 = 171,
        Emote_Dance3 = 172,
        Emote_FingerScratch = 173,
        Emote_HalfBackflip = 174,
        Emote_Handstand = 175,
        Emote_HuggerHeal = 176,
        Emote_JumpJack = 177,
        Emote_MiddleFings = 178,
        Emote_Peace = 179,
        Emote_PushUp = 180,
        Emote_Shrug = 181,
        Emote_Stretch = 182,
        Emote_Thumbnail1 = 183,
        Emote_Thumbnail2 = 184,
        Emote_ThumbsUp = 185,
        BoomMic_ToolTips = 186,
        Camera_ToolTips = 187,
        Clapper_ToolTips = 188,
        Defibrilator_ToolTips = 189,
        Disc_ToolTips = 190,
        FakeOldFlashlight = 191,
        FakeOldFlashlight_ToolTips = 192,
        Flare_ToolTips = 193,
        GooBall_ToolTips = 194,
        GrabberArm = 195,
        GrabberArm_ToolTips = 196,
        Hugger_ToolTips = 197,
        LongFlashlightPro_ToolTips = 198,
        LongFlashlight_ToolTips = 199,
        LostDisc = 200,
        LostDisc_ToolTips = 201,
        ModernFlashlightPro_ToolTips = 202,
        ModernFlashlight_ToolTips = 203,
        OldFlashlight_ToolTips = 204,
        PartyPopper_ToolTips = 205,
        ReporterMic_ToolTips = 206,
        ShockStick_ToolTips = 207,
        SoundPlayer_ToolTips = 208,
        WalkieTalkie_ToolTips = 209,
        WideFlashlight2_ToolTips = 210,
        WideFlashlight3_ToolTips = 211,
        Radio_ToolTips = 212,
        Emote_Applause_ToolTips = 213,
        Emote_Dance1_ToolTips = 214,
        Emote_Dance2_ToolTips = 215,
        Emote_Dance3_ToolTips = 216,
        Emote_FingerScratch_ToolTips = 217,
        Emote_HalfBackflip_ToolTips = 218,
        Emote_Handstand_ToolTips = 219,
        Emote_HuggerHeal_ToolTips = 220,
        Emote_JumpJack_ToolTips = 221,
        Emote_MiddleFings_ToolTips = 222,
        Emote_Peace_ToolTips = 223,
        Emote_PushUp_ToolTips = 224,
        Emote_Shrug_ToolTips = 225,
        Emote_Stretch_ToolTips = 226,
        Emote_Thumbnail1_ToolTips = 227,
        Emote_Thumbnail2_ToolTips = 228,
        Emote_ThumbsUp_ToolTips = 229,
        ThrowItemToolTip = 230,
        Endscreen1_1 = 231,
        Endscreen1_2 = 232,
        Endscreen1_3 = 233,
        Endscreen1_4 = 234,
        Endscreen1_5 = 235,
        Endscreen2_1 = 236,
        Endscreen2_2 = 237,
        Endscreen2_3 = 238,
        Endscreen2_4 = 239,
        Endscreen2_5 = 240,
        Endscreen3_1 = 241,
        Endscreen3_2 = 242,
        Endscreen3_3 = 243,
        Endscreen3_4 = 244,
        Endscreen3_5 = 245,
        Endscreen3_6 = 246,
        EndscreenDream = 247,
        Bomb = 248,
        Apple = 249,
        Sit = 250,
        Error_Steam_Title = 251,
        Error_Steam_Body = 252,
        Error_Auth_Failed = 253,
        Error_File_Not_Found = 254,
        Error_Save = 255,
        Error_RecordingsFolder = 256,
        Error_NoSave = 257,
        Error_HostLeft = 258,
        Error_Disconnected = 259,
        Error_Join = 260,
        Error_Delete_TempFolder = 261,
        Error_CreateRoom = 262,
        Error_VideoPath = 263,
        AddedToCart = 264,
        PushToTalk = 265,
        VoiceDetection = 266,
        FullScreenMode = 267,
        WindowedMode = 268,
        HighSetting = 269,
        LowSetting = 270,
        OnSetting = 271,
        OffSetting = 272,
        PressAnyKeySetting = 273,
        Emote_Applause_Text = 274,
        Emote_Dance1_Text = 275,
        Emote_Dance2_Text = 276,
        Emote_Dance3_Text = 277,
        Emote_FingerScratch_Text = 278,
        Emote_HalfBackflip_Text = 279,
        Emote_Handstand_Text = 280,
        Emote_HuggerHeal_Text = 281,
        Emote_JumpJack_Text = 282,
        Emote_MiddleFings_Text = 283,
        Emote_Peace_Text = 284,
        Emote_PushUp_Text = 285,
        Emote_Shrug_Text = 286,
        Emote_Stretch_Text = 287,
        Emote_Thumbnail1_Text = 288,
        Emote_Thumbnail2_Text = 289,
        Emote_ThumbsUp_Text = 290,
        Unlock = 291,
        BalaclavaHat = 292,
        BeanieHat = 293,
        BucketHatHat = 294,
        CatEarsHat = 295,
        ChefHat = 296,
        FloppyHat = 297,
        HomburgHat = 298,
        Hair1Hat = 299,
        Hat_BowlerHat = 300,
        Hat_CapHat = 301,
        Hat_ChildHat = 302,
        Hat_ClownHat = 303,
        Hat_CowboyHat = 304,
        Hat_CrownHat = 305,
        Hat_HaloHat = 306,
        Hat_HornsHat = 307,
        Hat_HotdogHat = 308,
        Hat_JesterHat = 309,
        Hat_KnifoHat = 310,
        Hat_MilkHat = 311,
        Hat_NewsHat = 312,
        Hat_PirateHat = 313,
        Hat_RugbyHat = 314,
        Hat_SavannahHat = 315,
        Hat_TooopHat = 316,
        Hat_TopHat = 317,
        PartyHat = 318,
        ShroomHat = 319,
        UshankaHat = 320,
        WitchHat = 321,
        NetworkBingoBongo_0_EmailTitle = 322,
        NetworkBingoBongo_0_DealName = 323,
        NetworkBingoBongo_0_Description = 324,
        NetworkBingoBongo_0_SuccessEmailBody = 325,
        NetworkBingoBongo_0_FailedEmailBody = 326,
        NetworkHoldTheBombo_9_EmailTitle = 327,
        NetworkHoldTheBombo_9_DealName = 328,
        NetworkHoldTheBombo_9_Description = 329,
        NetworkHoldTheBombo_9_SuccessEmailBody = 330,
        NetworkHoldTheBombo_9_FailedEmailBody = 331,
        NetworkInterviewer_2_EmailTitle = 332,
        NetworkInterviewer_2_DealName = 333,
        NetworkInterviewer_2_Description = 334,
        NetworkInterviewer_2_SuccessEmailBody = 335,
        NetworkInterviewer_2_FailedEmailBody = 336,
        NetworkJackass_4_EmailTitle = 337,
        NetworkJackass_4_DealName = 338,
        NetworkJackass_4_Description = 339,
        NetworkJackass_4_SuccessEmailBody = 340,
        NetworkJackass_4_FailedEmailBody = 341,
        NetworkMultiMonsterInFrameAtOnce_5_EmailTitle = 342,
        NetworkMultiMonsterInFrameAtOnce_5_DealName = 343,
        NetworkMultiMonsterInFrameAtOnce_5_Description = 344,
        NetworkMultiMonsterInFrameAtOnce_5_SuccessEmailBody = 345,
        NetworkMultiMonsterInFrameAtOnce_5_FailedEmailBody = 346,
        NetworkTaunting_3_EmailTitle = 347,
        NetworkTaunting_3_DealName = 348,
        NetworkTaunting_3_Description = 349,
        NetworkTaunting_3_SuccessEmailBody = 350,
        NetworkTaunting_3_FailedEmailBody = 351,
        NetworkWalletMoney_1_EmailTitle = 352,
        NetworkWalletMoney_1_DealName = 353,
        NetworkWalletMoney_1_Description = 354,
        NetworkWalletMoney_1_SuccessEmailBody = 355,
        NetworkWalletMoney_1_FailedEmailBody = 356,
        NoHat = 357,
        HatShop_AlreadyOwn = 358,
        HatShop_Buy = 359,
        HatShop_CantAfford = 360,
        Difficulty_VeryEasy = 361,
        Difficulty_Easy = 362,
        Difficulty_Medium = 363,
        Difficulty_Hard = 364,
        Difficulty_VeryHard = 365,
        Deal_Reward_Items = 366,
        Deal_Reward_Meta = 367,
        Deal_SignDeal = 368
    }

    private static Dictionary<Keys, string> m_StringDictionary;

    private static Dictionary<Locale, Dictionary<Keys, string>> m_LanguageStrings;

    private static bool m_MadeLocaleStrings;

    public static string GetLocalizedString(Keys key)
    {
        if (!m_MadeLocaleStrings)
        {
            MakeLocaleStrings();
        }
        if (m_StringDictionary == null || !m_StringDictionary.ContainsKey(key))
        {
            Debug.LogError("Cant find locale key for: " + key);
            return "LOCALIZATION ERROR";
        }
        return m_StringDictionary[key];
    }

    private static string GetLocalizedInternal(Locale locale, Keys key)
    {
        string text = LocalizationSettings.StringDatabase.GetLocalizedString(key.ToString(), locale, FallbackBehavior.UseProjectSettings);
        if (string.IsNullOrEmpty(text))
        {
            text = LocalizationSettings.StringDatabase.GetLocalizedString(key.ToString(), LocalizationSettings.ProjectLocale, FallbackBehavior.UseProjectSettings);
            if (string.IsNullOrEmpty(text))
            {
                text = "LOCALIZATION ERROR";
            }
        }
        return text;
    }

    public static void MakeLocaleStrings()
    {
        if (m_MadeLocaleStrings)
        {
            VerboseDebug.Log("Dont Redo Language Strings!");
            return;
        }
        m_LanguageStrings = new Dictionary<Locale, Dictionary<Keys, string>>();
        Keys[] array = (Keys[])Enum.GetValues(typeof(Keys));
        int num = array.Length;
        foreach (Locale locale in LocalizationSettings.AvailableLocales.Locales)
        {
            Dictionary<Keys, string> dictionary = new Dictionary<Keys, string>();
            for (int i = 0; i < num; i++)
            {
                Keys key = array[i];
                string localizedInternal = GetLocalizedInternal(locale, key);
                dictionary.Add(key, localizedInternal);
            }
            m_LanguageStrings.Add(locale, dictionary);
        }
        m_MadeLocaleStrings = true;
        OnLanguageSwitch();
    }

    public static void OnLanguageSwitch()
    {
        if (m_MadeLocaleStrings)
        {
            m_StringDictionary = m_LanguageStrings[LocalizationSettings.SelectedLocale];
        }
    }
}
