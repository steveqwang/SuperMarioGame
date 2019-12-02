using System;

namespace Game1.Utility
{
    [Serializable]
    //using Game1.Utility;
    public class Util
    {

        private static Util instance = new Util();
        public static Util Instance { get => instance; set { instance = value; } }
        private Util()
        {

        }
        private readonly int qBrandomLimitLow = 0;
        public int QBrandomLimitLow { get => qBrandomLimitLow; }

        private readonly double fiveF = 5f;
        public double FiveF { get => fiveF; }

        private readonly int int_3 = 3;
        public int Int_3 { get => int_3; }

        private readonly int int_1 = 1;
        public int Int_1 { get => int_1; }

        private readonly int int_15 = 15;
        public int Int_15 { get => int_15; }


        private readonly int qBrandomLimitHigh = 5;
        public int QBrandomLimitHigh { get => qBrandomLimitHigh; }

        private readonly int gold_positionFix_x = 5;
        public int Gold_positionFix_x { get => gold_positionFix_x; }

        private readonly int bonus_positionFix_y = 17;
        public int Bonus_positionFix_y { get => bonus_positionFix_y; }

        private readonly int vector_initial_i = 0;
        public int Vector_initial_i { get => vector_initial_i; }

        private readonly int vector_initial_j = 0;
        public int Vector_initial_j { get => vector_initial_j; }

        private readonly int viewMatrix_j_shift = 256;
        public int ViewMatrix_j_shift { get => viewMatrix_j_shift; }

        private readonly int viewMatrix_k = 0;
        public int ViewMatrix_k { get => viewMatrix_k; }

        private readonly float transition_width_change = 0.5f;
        public float Transition_width_change { get => transition_width_change; }

        private readonly int blockPixel = 16;
        public int BlockPixel { get => blockPixel; }

        private readonly int viewRange = 10;
        public int ViewRange { get => viewRange; }

        private readonly int blockIndex_ref = 0;
        public int BlockIndex_ref { get => blockIndex_ref; }

        private readonly float vector_fireball_j = 0f;
        public float Vector_fireball_j { get => vector_fireball_j; }

        private readonly float float_16f = 16f;
        public float Float_16f { get => float_16f; }

        private readonly int bowser_life = 20;
        public int Bowser_life { get => bowser_life; }

        private readonly float float_neg20f = -20f;
        public float Float_neg20f { get => float_neg20f; }


        private readonly float coli_mariBlock_Y_fix = 0.8f;
        public float Coli_mariBlock_Y_fix { get => coli_mariBlock_Y_fix; }

        private readonly int fireball_command_delay = 20;
        public int Fireball_command_delay { get => fireball_command_delay; }

        private readonly int fireball_command_delay_zero = 0;
        public int Fireball_command_delay_zero { get => fireball_command_delay_zero; }

        private readonly float go_down_vec2_y = 1.23f;
        public float Go_down_vec2_y { get => go_down_vec2_y; }

        private readonly int turn_left_vec_x = -2;
        public int Turn_left_vec_x { get => turn_left_vec_x; }

        private readonly int turn_R_vec_x = 2;
        public int Turn_R_vec_x { get => turn_R_vec_x; }

        private readonly int goomba_D_timer = 0;
        public int Goomba_D_timer { get => goomba_D_timer; }

        private readonly int goomba_draw_vec_x = 0;
        public int Goomba_draw_vec_x { get => goomba_draw_vec_x; }

        private readonly int goomba_draw_vec_y = 1000;
        public int Goomba_draw_vec_y { get => goomba_draw_vec_y; }

        private readonly int goomba_deathtime_ref = 100;
        public int Goomba_deathtime_ref { get => goomba_deathtime_ref; }

        private readonly int goomba_deathtimer = 0;
        public int Goomba_deathtimer { get => goomba_deathtimer; }

        private readonly int koopa_deathtimer = 0;
        public int Koopa_deathtimer { get => koopa_deathtimer; }

        private readonly int bowser_deathtimer = 0;
        public int Bowser_deathtimer { get => bowser_deathtimer; }


        private readonly int koopa_kicktimer = 0;

        public int Koopa_kicktimer { get => koopa_kicktimer; }

        private readonly int koopa_revivetimer = 0;
        public int Koopa_revivetimer { get => koopa_revivetimer; }

        private readonly int koopa_deathtimer_BeStomped = 0;
        public int Koopa_deathtimer_BeStomped { get => koopa_deathtimer_BeStomped; }

        private readonly int koopa_deathtimer_revive = 0;
        public int Koopa_deathtimer_revive { get => koopa_deathtimer_revive; }

        private readonly int koopa_kicktimer_revive = 0;
        public int Koopa_kicktimer_revive { get => koopa_kicktimer_revive; }

        private readonly int koopa_revivetimer_revive = 0;
        public int Koopa_revivetimer_revive { get => koopa_revivetimer_revive; }

        private readonly int koopa_draw_vecx = 0;
        public int Koopa_draw_vecx { get => koopa_draw_vecx; }

        private readonly int koopa_draw_vecy = 1000;
        public int Koopa_draw_vecy { get => koopa_draw_vecy; }

        private readonly int koopa_revivetimer_update = 0;
        public int Koopa_revivetimer_update { get => koopa_revivetimer_update; }

        private readonly int koopa_update_ref250 = 250;
        public int Koopa_update_ref250 { get => koopa_update_ref250; }

        private readonly int koopa_update_ref100 = 100;
        public int Koopa_update_ref100 { get => koopa_update_ref100; }

        private readonly int koopa_deathtimer_update_100case = 0;
        public int Koopa_deathtimer_update_100case { get => koopa_deathtimer_update_100case; }

        private readonly int koopa_kickref = 15;
        public int Koopa_kickref { get => koopa_kickref; }

        private readonly int sixteen = 16;
        public int Sixteen { get => sixteen; }


        private readonly int koopa_kicktimer_dirtop = 0;
        public int Koopa_kicktimer_dirtop { get => koopa_kicktimer_dirtop; }

        private readonly string beveledBlock = "beveledBlock";
        public string BeveledBlock { get => beveledBlock; }

        private readonly string brick = "Brick";
        public string Brick { get => brick; }

        private readonly string hidden = "Hidden";
        public string Hidden { get => hidden; }

        private readonly string string_1_1 = "1-1";
        public string String_1_1 { get => string_1_1; }

        private readonly string string_1_2 = "1-2";
        public string String_1_2 { get => string_1_2; }
        private readonly string string_2_2 = "2-2";
        public string String_2_2 { get => string_2_2; }

        private readonly string string_World = "World:";
        public string String_World { get => string_World; }

        private readonly string string_Scores = "Scores:";
        public string String_Scores { get => string_Scores; }

        private readonly string string_xxx = "Life:";
        public string String_life { get => string_xxx; }

        private readonly string string_Timer = "Timer: ";
        public string String_Timer { get => string_Timer; }

        private readonly string string_PAUSE = "PAUSE";
        public string String_PAUSE { get => string_PAUSE; }


        private readonly string ground = "Ground";
        public string Ground { get => ground; }

        private readonly string used = "Used";
        public string Used { get => used; }

        private readonly string pipeLarge = "pipeLarge";
        public string PipeLarge { get => pipeLarge; }

        private readonly string question = "Question";
        public string Question { get => question; }


        private readonly string goombaWalk = "GoombaWalk";
        public string GoombaWalk { get => goombaWalk; }

        private readonly string koopa_walk_left = "koopa_walk_left";
        public string Koopa_walk_left { get => koopa_walk_left; }

        private readonly string koopa_walk_right = "koopa_walk_right";
        public string Koopa_walk_right { get => koopa_walk_right; }

        private readonly string koopaFlipped = "KoopaFlipped";
        public string KoopaFlipped { get => koopaFlipped; }

        private readonly string koopaStomped = "KoopaStomped";
        public string KoopaStomped { get => koopaStomped; }

        private readonly string goombaStomped = "GoombaStomped";
        public string GoombaStomped { get => goombaStomped; }

        private readonly string goombaFlipped = "GoombaFlipped";
        public string GoombaFlipped { get => goombaFlipped; }

        private readonly string bowserMoveLeft = "GameSprite/BowserLeft";
        public string BowserMoveLeft { get => bowserMoveLeft; }

        private readonly string bowserMoveRight = "GameSprite/BowserRight";
        public string BowserMoveRight { get => bowserMoveRight; }


        private readonly string gameSprite_FireBallLeft = "GameSprite/FireBallLeft";
        public string GameSprite_FireBallLeft { get => gameSprite_FireBallLeft; }

        private readonly string gameSprite_FireBallRight = "GameSprite/FireBallRight";
        public string GameSprite_FireBallRight { get => gameSprite_FireBallRight; }

        private readonly string gameSprite_FireballExplosion = "GameSprite/FireballExplosion";
        public string GameSprite_FireballExplosion { get => gameSprite_FireballExplosion; }

        private readonly string gameSprite_Castle = "GameSprite/Castle";
        public string GameSprite_Castle { get => gameSprite_Castle; }

        private readonly string gameSprite_FlagStuff = "GameSprite/FlagStuff";
        public string GameSprite_FlagStuff { get => gameSprite_FlagStuff; }



        private readonly int createLeftFireBallSpriteY = 1;
        public int CreateLeftFireBallSpriteY { get => createLeftFireBallSpriteY; }

        private readonly int createLeftFireBallSpriteZ = 4;
        public int CreateLeftFireBallSpriteZ { get => createLeftFireBallSpriteZ; }

        private readonly int createLeftFireBallSpriteW = 4;
        public int CreateLeftFireBallSpriteW { get => createLeftFireBallSpriteW; }


        private readonly int createRightFireBallSpriteY = 1;
        public int CreateRightFireBallSpriteY { get => createRightFireBallSpriteY; }

        private readonly int createRightFireBallSpriteZ = 4;
        public int CreateRightFireBallSpriteZ { get => createRightFireBallSpriteZ; }

        private readonly int createRightFireBallSpriteW = 4;
        public int CreateRightFireBallSpriteW { get => createRightFireBallSpriteW; }





        private readonly int createExplodedFireBallSpriteY = 1;
        public int CreateExplodedFireBallSpriteY { get => createExplodedFireBallSpriteY; }

        private readonly int createExplodedFireBallSpriteZ = 3;
        public int CreateExplodedFireBallSpriteZ { get => createExplodedFireBallSpriteZ; }

        private readonly int createExplodedFireBallSpriteW = 3;
        public int CreateExplodedFireBallSpriteW { get => createExplodedFireBallSpriteW; }


        private readonly int createFlagStuffSpriteY = 1;
        public int CreateFlagStuffSpriteY { get => createFlagStuffSpriteY; }

        private readonly int createFlagStuffSpriteZ = 5;
        public int CreateFlagStuffSpriteZ { get => createFlagStuffSpriteZ; }

        private readonly int createFlagStuffSpriteW = 5;
        public int CreateFlagStuffSpriteW { get => createFlagStuffSpriteW; }




        private readonly string star = "Star";
        public string Star { get => star; }

        private readonly string greenmushroom = "Greenmushroom";
        public string Greenmushroom { get => greenmushroom; }

        private readonly string redmushroom = "Redmushroom";
        public string Redmushroom { get => redmushroom; }

        private readonly string flower = "Flower";
        public string Flower { get => flower; }

        private readonly string gold = "Gold";
        public string Gold { get => gold; }







        private readonly string sprite_deadMarioSpritesheet = "Sprite/deadMarioSpritesheet";
        public string Sprite_deadMarioSpritesheet { get => sprite_deadMarioSpritesheet; }

        private readonly string sprite_fireMarioLeftCrouchSpritesheet = "Sprite/fireMarioLeftCrouchSpritesheet";
        public string Sprite_fireMarioLeftCrouchSpritesheet { get => sprite_fireMarioLeftCrouchSpritesheet; }

        private readonly string sprite_fireMarioLeftIdleSpritesheet = "Sprite/fireMarioLeftIdleSpritesheet";
        public string Sprite_fireMarioLeftIdleSpritesheet { get => sprite_fireMarioLeftIdleSpritesheet; }

        private readonly string sprite_fireMarioLeftRunSpritesheet = "Sprite/fireMarioLeftRunSpritesheet";
        public string Sprite_fireMarioLeftRunSpritesheet { get => sprite_fireMarioLeftRunSpritesheet; }

        private readonly string sprite_fireMarioLeftJumpSpritesheet = "Sprite/fireMarioLeftJumpSpritesheet";
        public string Sprite_fireMarioLeftJumpSpritesheet { get => sprite_fireMarioLeftJumpSpritesheet; }

        private readonly string sprite_fireMarioRightCrouchSpritesheet = "Sprite/fireMarioRightCrouchSpritesheet";
        public string Sprite_fireMarioRightCrouchSpritesheet { get => sprite_fireMarioRightCrouchSpritesheet; }

        private readonly string sprite_fireMarioRightIdleSpritesheet = "Sprite/fireMarioRightIdleSpritesheet";
        public string Sprite_fireMarioRightIdleSpritesheet { get => sprite_fireMarioRightIdleSpritesheet; }

        private readonly string sprite_fireMarioRightRunSpritesheet = "Sprite/fireMarioRightRunSpritesheet";
        public string Sprite_fireMarioRightRunSpritesheet { get => sprite_fireMarioRightRunSpritesheet; }

        private readonly string sprite_fireMarioRightJumpSpritesheet = "Sprite/fireMarioRightJumpSpritesheet";
        public string Sprite_fireMarioRightJumpSpritesheet { get => sprite_fireMarioRightJumpSpritesheet; }

        private readonly string sprite_smallMarioLeftIdleSpritesheet = "Sprite/smallMarioLeftIdleSpritesheet";
        public string Sprite_smallMarioLeftIdleSpritesheet { get => sprite_smallMarioLeftIdleSpritesheet; }

        private readonly string sprite_smallMarioLeftRunSpritesheet = "Sprite/smallMarioLeftRunSpritesheet";
        public string Sprite_smallMarioLeftRunSpritesheet { get => sprite_smallMarioLeftRunSpritesheet; }

        private readonly string sprite_smallMarioLeftJumpSpritesheet = "Sprite/smallMarioLeftJumpSpritesheet";
        public string Sprite_smallMarioLeftJumpSpritesheet { get => sprite_smallMarioLeftJumpSpritesheet; }

        private readonly string sprite_smallMarioRightIdleSpritesheet = "Sprite/smallMarioRightIdleSpritesheet";
        public string Sprite_smallMarioRightIdleSpritesheet { get => sprite_smallMarioRightIdleSpritesheet; }

        private readonly string sprite_smallMarioRightRunSpritesheet = "Sprite/smallMarioRightRunSpritesheet";
        public string Sprite_smallMarioRightRunSpritesheet { get => sprite_smallMarioRightRunSpritesheet; }

        private readonly string sprite_smallMarioRightJumpSpritesheet = "Sprite/smallMarioRightJumpSpritesheet";
        public string Sprite_smallMarioRightJumpSpritesheet { get => sprite_smallMarioRightJumpSpritesheet; }

        private readonly string sprite_bigMarioLeftCrouchSpritesheet = "Sprite/bigMarioLeftCrouchSpritesheet";
        public string Sprite_bigMarioLeftCrouchSpritesheet { get => sprite_bigMarioLeftCrouchSpritesheet; }

        private readonly string sprite_bigMarioLeftIdleSpritesheet = "Sprite/bigMarioLeftIdleSpritesheet";
        public string Sprite_bigMarioLeftIdleSpritesheet { get => sprite_bigMarioLeftIdleSpritesheet; }

        private readonly string sprite_bigMarioLeftRunSpritesheet = "Sprite/bigMarioLeftRunSpritesheet";
        public string Sprite_bigMarioLeftRunSpritesheet { get => sprite_bigMarioLeftRunSpritesheet; }

        private readonly string sprite_bigMarioLeftJumpSpritesheet = "Sprite/bigMarioLeftJumpSpritesheet";
        public string Sprite_bigMarioLeftJumpSpritesheet { get => sprite_bigMarioLeftJumpSpritesheet; }

        private readonly string sprite_bigMarioRightCrouchSpritesheet = "Sprite/bigMarioRightCrouchSpritesheet";
        public string Sprite_bigMarioRightCrouchSpritesheet { get => sprite_bigMarioRightCrouchSpritesheet; }

        private readonly string sprite_bigMarioRightIdleSpritesheet = "Sprite/bigMarioRightIdleSpritesheet";
        public string Sprite_bigMarioRightIdleSpritesheet { get => sprite_bigMarioRightIdleSpritesheet; }

        private readonly string sprite_bigMarioRightRunSpritesheet = "Sprite/bigMarioRightRunSpritesheet";
        public string Sprite_bigMarioRightRunSpritesheet { get => sprite_bigMarioRightRunSpritesheet; }

        private readonly string sprite_bigMarioRightJumpSpritesheet = "Sprite/bigMarioRightJumpSpritesheet";
        public string Sprite_bigMarioRightJumpSpritesheet { get => sprite_bigMarioRightJumpSpritesheet; }

        private readonly string spriteStar_starSmallLeftIdleMario = "SpriteStar/starSmallLeftIdleMario";
        public string SpriteStar_starSmallLeftIdleMario { get => spriteStar_starSmallLeftIdleMario; }

        private readonly string spriteStar_starSmallLeftRunMario = "SpriteStar/starSmallLeftRunMario";
        public string SpriteStar_starSmallLeftRunMario { get => spriteStar_starSmallLeftRunMario; }

        private readonly string spriteStar_starSmallLeftJumpMario = "SpriteStar/starSmallLeftJumpMario";
        public string SpriteStar_starSmallLeftJumpMario { get => spriteStar_starSmallLeftJumpMario; }

        private readonly string spriteStar_starSmallRightIdleMario = "SpriteStar/starSmallRightIdleMario";
        public string SpriteStar_starSmallRightIdleMario { get => spriteStar_starSmallRightIdleMario; }

        private readonly string spriteStar_starSmallRightRUnMario = "SpriteStar/starSmallRightRUnMario";
        public string SpriteStar_starSmallRightRUnMario { get => spriteStar_starSmallRightRUnMario; }

        private readonly string spriteStar_starSmallRightJumpMario = "SpriteStar/starSmallRightJumpMario";
        public string SpriteStar_starSmallRightJumpMario { get => spriteStar_starSmallRightJumpMario; }

        private readonly string spriteStar_starBigLeftCrouchMario = "SpriteStar/starBigLeftCrouchMario";
        public string SpriteStar_starBigLeftCrouchMario { get => spriteStar_starBigLeftCrouchMario; }

        private readonly string spriteStar_starBigLeftIdleMario = "SpriteStar/starBigLeftIdleMario";
        public string SpriteStar_starBigLeftIdleMario { get => spriteStar_starBigLeftIdleMario; }


        private readonly string spriteStar_starBigLeftRunMario = "SpriteStar/starBigLeftRunMario";
        public string SpriteStar_starBigLeftRunMario { get => spriteStar_starBigLeftRunMario; }

        private readonly string spriteStar_starBigLeftJumpMario = "SpriteStar/starBigLeftJumpMario";
        public string SpriteStar_starBigLeftJumpMario { get => spriteStar_starBigLeftJumpMario; }

        private readonly string spriteStar_starBigRightCrouchMario = "SpriteStar/starBigRightCrouchMario";
        public string SpriteStar_starBigRightCrouchMario { get => spriteStar_starBigRightCrouchMario; }

        private readonly string spriteStar_starBigRightIdleMario = "SpriteStar/starBigRightIdleMario";
        public string SpriteStar_starBigRightIdleMario { get => spriteStar_starBigRightIdleMario; }

        private readonly string spriteStar_starBigRightRunMario = "SpriteStar/starBigRightRunMario";
        public string SpriteStar_starBigRightRunMario { get => spriteStar_starBigRightRunMario; }

        private readonly string spriteStar_starBigRightJumpMario = "SpriteStar/starBigRightJumpMario";
        public string SpriteStar_starBigRightJumpMario { get => spriteStar_starBigRightJumpMario; }


        private readonly int dynamicSprite_combo_1 = 1;
        public int DynamicSprite_combo_1 { get => dynamicSprite_combo_1; }

        private readonly int dynamicSprite_combo_3 = 3;
        public int DynamicSprite_combo_3 { get => dynamicSprite_combo_3; }

        private readonly int dynamicSprite_combo_5 = 5;
        public int DynamicSprite_combo_5 { get => dynamicSprite_combo_5; }


        private readonly string menu_MainLogo = "Menu/MainLogo";
        public string Menu_MainLogo { get => menu_MainLogo; }

        private readonly string menu_Consolas = "Menu/Consolas";
        public string Menu_Consolas { get => menu_Consolas; }

        private readonly string menu_MushroomSelector = "Menu/MushroomSelector";
        public string Menu_MushroomSelector { get => menu_MushroomSelector; }
        



        private readonly string scenery_bigBush = "Scenery/bigBush";
        public string Scenery_bigBush { get => scenery_bigBush; }

        private readonly string scenery_bigHill = "Scenery/bigHill";
        public string Scenery_bigHill { get => scenery_bigHill; }

        private readonly string scenery_bigCloud = "Scenery/bigCloud";
        public string Scenery_bigCloud { get => scenery_bigCloud; }

        private readonly string scenery_smallBush = "Scenery/smallBush";
        public string Scenery_smallBush { get => scenery_smallBush; }

        private readonly string scenery_smalCloud = "Scenery/smalCloud";
        public string Scenery_smalCloud { get => scenery_smalCloud; }

        private readonly string scenery_smallHill = "Scenery/smallHill";
        public string Scenery_smallHill { get => scenery_smallHill; }

        private readonly string load_rec1 = "1-1.xml";
        public string Load_rec1 { get => load_rec1; }

        private readonly int load_rec2 = 208;
        public int Load_rec2 { get => load_rec2; }

        private readonly int load_rec3 = 16;
        public int Load_rec3 { get => load_rec3; }

        private readonly string create_rec1 = "../../../../Content/Level/";
        public string Create_rec1 { get => create_rec1; }

        private readonly string readToFollowing_rec1 = "Objects";
        public string ReadToFollowing_rec1 { get => readToFollowing_rec1; }

        private readonly string type_string = "Type";
        public string Type_string { get => type_string; }

        private readonly string string_X = "X";
        public string String_X { get => string_X; }

        private readonly string string_Y = "Y";
        public string String_Y { get => string_Y; }



        private readonly string string_Player = "Player";
        public string String_Player { get => string_Player; }

        private readonly string string_Block = "Block";
        public string String_Block { get => string_Block; }

        private readonly string string_Enemy = "Enemy";
        public string String_Enemy { get => string_Enemy; }

        private readonly string string_Item = "Item";
        public string String_Item { get => string_Item; }

        private readonly string string_Scenery = "Scenery";
        public string String_Scenery { get => string_Scenery; }

        private readonly string string_GameObject = "GameObject";
        public string String_GameObject { get => string_GameObject; }

        private readonly string string_MarioStarSmallState = "MarioStarSmallState";
        public string String_MarioStarSmallState { get => string_MarioStarSmallState; }

        private readonly int zero = 0;
        public int Zero { get => zero; }

        private readonly int one = 1;
        public int One { get => one; }

        private readonly int ten = 10;
        public int Ten { get => ten; }

        private readonly string string_MarioStarBigState = "MarioStarBigState";
        public string String_MarioStarBigState { get => string_MarioStarBigState; }

        private readonly int hundred = 100;
        public int Hundred { get => hundred; }

        private readonly string string_MarioFireState = "MarioFireState";
        public string String_MarioFireState { get => string_MarioFireState; }

        private readonly string string_MarioBigState = "MarioBigState";
        public string String_MarioBigState { get => string_MarioBigState; }

        private readonly string string_MarioSmallState = "MarioSmallState";
        public string String_MarioSmallState { get => string_MarioSmallState; }

        private readonly int threeFifty = 350;
        public int ThreeFifty { get => threeFifty; }

        private readonly int fiveHundreds = 500;
        public int FiveHundreds { get => fiveHundreds; }

        private readonly int twoFive = 25;
        public int TwoFive { get => twoFive; }

        private readonly int five = 5;
        public int Five { get => five; }


        private readonly int twoHundreds = 200;
        public int TwoHundreds { get => twoHundreds; }

        private readonly int threeHundreds = 300;
        public int ThreeHundreds { get => threeHundreds; }

        private readonly int fourHundreds = 400;
        public int FourHundreds { get => fourHundreds; }

        private readonly int two2ty = 220;
        public int Two2ty { get => two2ty; }

        private readonly string string_Begin = "Begin";
        public string String_Begin { get => string_Begin; }

        private readonly string string_Quit = "Quit";
        public string String_Quit { get => string_Quit; }

        private readonly string string_longSpace = "   ";
        public string String_longSpace { get => string_longSpace; }


        private readonly int one3rty = 130;
        public int One3rty { get => one3rty; }

        private readonly int one7ty = 170;
        public int One7ty { get => one7ty; }


        private readonly int one5ty = 150;
        public int One5ty { get => one5ty; }

        private readonly int two8ty = 280;
        public int Two8ty { get => two8ty; }

        private readonly int three5ty = 350;
        public int Three5ty { get => three5ty; }


        private readonly int damageTimer = 40;
        public int DamageTimer { get => damageTimer; }

        private readonly int twenty = 20;
        public int Twenty { get => twenty; }

        private readonly int twoThousands = 2000;
        public int TwoThousands { get => twoThousands; }

        private readonly int thousand = 1000;
        public int Thousand { get => thousand; }


        private readonly string string_Game_Over = "Game Over";
        public string String_Game_Over { get => string_Game_Over; }

        private readonly string string_tryAgain = "Try Again?";
        public string String_tryAgain { get => string_tryAgain; }

        private readonly int tryAgainX = 190;
        public int TryAgainX { get => tryAgainX; }

        private readonly int totalTimer = 600;
        public int TotalTimer { get => totalTimer; }

        private readonly int itemScore = 100;
        public int ItemScore { get => itemScore; }

        private readonly int enemyScore = 100;
        public int EnemyScore { get => enemyScore; }

        private readonly int bossScore = 3000;
        public int BossScore { get => bossScore; }

        private readonly int enemyMultipleKillExtraScore = 50;
        public int EnemyMultipleKillExtraScore { get => enemyMultipleKillExtraScore; }

        private readonly string string_GOBIG = "GOBIG";
        public string String_GOBIG { get => string_GOBIG; }

        private readonly string string_XFIRE = "XFIRE";
        public string String_XFIRE { get => string_XFIRE; }

        private readonly string string_SMALL = "SMALL";
        public string String_SMALL { get => string_SMALL; }

        private readonly int createLeftFireShotSpriteY = 1;
        public int CreateLeftFireShotSpriteY { get => createLeftFireShotSpriteY; }
        private readonly int createLeftFireShotSpriteZ = 2;
        public int CreateLeftFireShotSpriteZ { get => createLeftFireShotSpriteZ; }
        private readonly int createLeftFireShotSpriteW = 4;
        public int CreateLeftFireShotSpriteW { get => createLeftFireShotSpriteW; }

        private readonly int createRightFireShotSpriteY = 1;
        public int CreateRightFireShotSpriteY { get => createRightFireShotSpriteY; }
        private readonly int createRightFireShotSpriteZ = 2;
        public int CreateRightFireShotSpriteZ { get => createRightFireShotSpriteZ; }
        private readonly int createRightFireShotSpriteW = 4;
        public int CreateRightFireShotSpriteW { get => createRightFireShotSpriteW; }

        private readonly int createFireHellSpriteColumn = 3;
        public int CreateFireHellSpriteColumn { get => createFireHellSpriteColumn; }

        private readonly int createFireHellSpriteRow = 1;
        public int CreateFireHellSpriteRow { get => createFireHellSpriteRow; }

        private readonly int createFireHellSpriteDelay = 4;
        public int CreateFireHellSpriteDelay { get => createFireHellSpriteDelay; }
        private float createFireShotLife = 1.3f;
        public float CreateFireShotLife { get => createFireShotLife; }
        private readonly float fireShotMoveLeft = -200f;
        public float FireShotMoveLeft { get => fireShotMoveLeft; }

        private readonly float fireShotMoveRight = 200f;
        public float FireShotMoveRight { get => fireShotMoveRight; }
        private readonly int minusThousand = -1000;
        public int MinusThousand { get => minusThousand; }
        private readonly float fireHellVelocity = -100f;
        public float FireHellVelocity { get => fireHellVelocity; }

        //using Game1.Utility;
        //Util.Instance.
    }
}

