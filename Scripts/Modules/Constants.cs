
public class Constants
{
    public string InGameData = "{\"Character\":{\"Health\":50,\"Coins\":150},\"InventoryInfo\":{\"ItemInfo\":[]},\"ActiveLevel\":{\"CurrentLevel\":0,\"Position\":null}}";
    public string GameData = @"{
  ""UnlockedStages"": [ 0 ],
  ""StageList"": 
  {
    ""Stage"": [
      {
        ""StageLevel"": 0,
        ""StageName"": ""Hostile Forest"",
        ""UnLocked"": true,
        ""ShowCutScene"": true,
        ""StageRecordStack"": { ""StageRecord"": [] }
      },
      {
        ""StageLevel"": 1,
        ""StageName"": ""Cave of the Lost"",
        ""UnLocked"": false,
        ""ShowCutScene"": true,
        ""StageRecordStack"": { ""StageRecord"": [] }
      },
      {
        ""StageLevel"": 2,
        ""StageName"": ""Icy Mountain"",
        ""UnLocked"": false,
        ""ShowCutScene"": true,
        ""StageRecordStack"": { ""StageRecord"": [] }
      },
      {
        ""StageLevel"": 3,
        ""StageName"": ""The Rocky Mountain"",
        ""UnLocked"": false,
        ""ShowCutScene"": true,
        ""StageRecordStack"": { ""StageRecord"": [] }
      }
    ]
  }}";
    public string ShopData = "{\"ShopItemList\": [{\"ID\": 2,\"Price\": 250,\"Available\": true},{\"ID\": 3,\"Price\": 100,\"Available\": true}]}";
    public string ItemList = "{\"ListOfItems\":[{\"ID\":1,\"ItemProperties\":{\"Name\":\"Sword\",\"Type\":\"HandWeapon\",\"SlotType\":\"Single\",\"SpriteName\":\"sword\",\"Damage\":15,\"KnockBack\":15,\"XScale\":0.0,\"YScale\":0.0,\"Cooldown\":0.0,\"LastingAttack\":0.0,\"ItemPolygonPath\":{\"ItemVector2D\":[{\"X\":-0.14,\"Y\":-0.295},{\"X\":-0.11,\"Y\":-0.235},{\"X\":-0.12,\"Y\":-0.155},{\"X\":0.33,\"Y\":0.145},{\"X\":0.44,\"Y\":0.265},{\"X\":0.44,\"Y\":0.295},{\"X\":0.34,\"Y\":0.295},{\"X\":0.27,\"Y\":0.265},{\"X\":0.18,\"Y\":0.205},{\"X\":-0.22,\"Y\":-0.065},{\"X\":-0.26,\"Y\":0.005},{\"X\":-0.31,\"Y\":0.015},{\"X\":-0.34,\"Y\":-0.045},{\"X\":-0.27,\"Y\":-0.105},{\"X\":-0.42,\"Y\":-0.175},{\"X\":-0.44,\"Y\":-0.205},{\"X\":-0.44,\"Y\":-0.285},{\"X\":-0.43,\"Y\":-0.295},{\"X\":-0.33,\"Y\":-0.295},{\"X\":-0.21,\"Y\":-0.205},{\"X\":-0.18,\"Y\":-0.285},{\"X\":-0.15,\"Y\":-0.295}]}}},{\"ID\":2,\"ItemProperties\":{\"Name\":\"DiamondSword\",\"Type\":\"HandWeapon\",\"SlotType\":\"Single\",\"SpriteName\":\"diamondsword\",\"Damage\":28,\"KnockBack\":20,\"XScale\":0.0,\"YScale\":0.0,\"Cooldown\":0.0,\"LastingAttack\":0.0,\"ItemPolygonPath\":{\"ItemVector2D\":[{\"X\":-0.255,\"Y\":-0.315},{\"X\":-0.205,\"Y\":-0.315},{\"X\":-0.145,\"Y\":-0.255},{\"X\":-0.145,\"Y\":-0.215},{\"X\":-0.155,\"Y\":-0.195},{\"X\":0.195,\"Y\":0.045},{\"X\":0.455,\"Y\":0.225},{\"X\":0.495,\"Y\":0.265},{\"X\":0.545,\"Y\":0.345},{\"X\":0.545,\"Y\":0.375},{\"X\":0.525,\"Y\":0.385},{\"X\":0.455,\"Y\":0.385},{\"X\":0.365,\"Y\":0.345},{\"X\":-0.265,\"Y\":-0.095},{\"X\":-0.255,\"Y\":-0.055},{\"X\":-0.335,\"Y\":-0.025},{\"X\":-0.395,\"Y\":-0.085},{\"X\":-0.375,\"Y\":-0.185},{\"X\":-0.445,\"Y\":-0.225},{\"X\":-0.545,\"Y\":-0.285},{\"X\":-0.565,\"Y\":-0.295},{\"X\":-0.565,\"Y\":-0.335},{\"X\":-0.555,\"Y\":-0.385},{\"X\":-0.485,\"Y\":-0.415},{\"X\":-0.475,\"Y\":-0.415},{\"X\":-0.395,\"Y\":-0.335},{\"X\":-0.315,\"Y\":-0.265}]}}},{\"ID\":3,\"ItemProperties\":{\"Name\":\"GoldenSword\",\"Type\":\"HandWeapon\",\"SlotType\":\"Single\",\"SpriteName\":\"goldensword\",\"Damage\":34,\"KnockBack\":25,\"XScale\":0.0,\"YScale\":0.0,\"Cooldown\":0.0,\"LastingAttack\":0.0,\"ItemPolygonPath\":{\"ItemVector2D\":[{\"X\":-0.18,\"Y\":-0.405},{\"X\":-0.04,\"Y\":-0.305},{\"X\":0.04,\"Y\":-0.225},{\"X\":0.13,\"Y\":-0.095},{\"X\":0.16,\"Y\":-0.015},{\"X\":0.25,\"Y\":0.045},{\"X\":0.39,\"Y\":0.165},{\"X\":0.41,\"Y\":0.175},{\"X\":0.43,\"Y\":0.195},{\"X\":0.54,\"Y\":0.295},{\"X\":0.54,\"Y\":0.415},{\"X\":0.52,\"Y\":0.425},{\"X\":0.44,\"Y\":0.435},{\"X\":0.42,\"Y\":0.435},{\"X\":0.36,\"Y\":0.395},{\"X\":0.26,\"Y\":0.355},{\"X\":0.11,\"Y\":0.235},{\"X\":0.01,\"Y\":0.145},{\"X\":-0.08,\"Y\":0.145},{\"X\":-0.19,\"Y\":0.095},{\"X\":-0.35,\"Y\":0.015},{\"X\":-0.37,\"Y\":-0.045},{\"X\":-0.43,\"Y\":-0.035},{\"X\":-0.45,\"Y\":-0.155},{\"X\":-0.39,\"Y\":-0.225},{\"X\":-0.52,\"Y\":-0.285},{\"X\":-0.54,\"Y\":-0.305},{\"X\":-0.54,\"Y\":-0.375},{\"X\":-0.52,\"Y\":-0.425},{\"X\":-0.49,\"Y\":-0.435},{\"X\":-0.42,\"Y\":-0.435},{\"X\":-0.3,\"Y\":-0.325},{\"X\":-0.27,\"Y\":-0.385},{\"X\":-0.24,\"Y\":-0.395}]}}}]}";
    public string Status = "{\"ShowStages\":false,\"ShowTutorial\":true,\"ShowIntro\":true}";
    public string StageQuestions = @"{
  ""Chapter"": [
    {
      ""QuestionPool"": [
        {
          ""Question"": ""Find the difference: 45 - 9 =??"",
          ""Choices"": [ ""36"", ""34"", ""35"", ""37"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the difference of 38 and 6??"",
          ""Choices"": [ ""34"", ""32"", ""35"", ""30"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the difference: 85 - 7 =??"",
          ""Choices"": [ ""78"", ""74"", ""77"", ""76"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the difference of 58 and 3??"",
          ""Choices"": [ ""51"", ""53"", ""55"", ""52"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Find the difference: 65 - 6=??"",
          ""Choices"": [ ""56"", ""54"", ""55"", ""59"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is the difference of 99 and 7??"",
          ""Choices"": [ ""92"", ""88"", ""93"", ""91"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the difference: 27 - 5=??"",
          ""Choices"": [ ""19"", ""11"", ""23"", ""22"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is the difference of 32 and 4??"",
          ""Choices"": [ ""24"", ""27"", ""28"", ""29"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Find the difference: 63 - 9=??"",
          ""Choices"": [ ""50"", ""54"", ""58"", ""53"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is the difference of 26 and 7??"",
          ""Choices"": [ ""17"", ""22"", ""14"", ""19"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Find the difference: 77 - 14=??"",
          ""Choices"": [ ""63"", ""62"", ""64"", ""60"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the difference of 25 and 11=??"",
          ""Choices"": [ ""10"", ""14"", ""11"", ""15"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the difference: 85 - 12=??"",
          ""Choices"": [ ""72"", ""78"", ""73"", ""77"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is the difference of 69 and 17=??"",
          ""Choices"": [ ""53"", ""52"", ""54"", ""44"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the difference: 85 - 13=??"",
          ""Choices"": [ ""70"", ""77"", ""79"", ""72"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is the difference of 46 and 15??"",
          ""Choices"": [ ""37"", ""32"", ""34"", ""31"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Find the difference: 33 - 10=??"",
          ""Choices"": [ ""23"", ""22"", ""24"", ""20"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the difference of 95 and 11=??"",
          ""Choices"": [ ""80"", ""84"", ""81"", ""85"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the difference: 68 - 12=??"",
          ""Choices"": [ ""52"", ""58"", ""56"", ""57"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is the difference of 79 and 19=??"",
          ""Choices"": [ ""63"", ""60"", ""64"", ""54"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract ?74.00 from ?97.00??"",
          ""Choices"": [ ""?24.00"", ""?23.00"", ""?25.00"", ""?22.00"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract ?42.00 from ?68.00??"",
          ""Choices"": [ ""?24.00"", ""?23.00"", ""?25.00"", ""?26.00"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What will you get when you subtract ?61.00 from ?73.00??"",
          ""Choices"": [ ""?14.00"", ""?13.00"", ""?15.00"", ""?12.00"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What will you get when you subtract ?34.00 from ?48.00??"",
          ""Choices"": [ ""?14.00"", ""?13.00"", ""?15.00"", ""?12.00"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What will you get when you subtract ?43.00 from ?65.00??"",
          ""Choices"": [ ""?24.00"", ""?22.00"", ""?25.00"", ""?22.00"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract ?34.00 from ?75.00??"",
          ""Choices"": [ ""?44.00"", ""?43.00"", ""?41.00"", ""?42.00"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What will you get when you subtract ?13.00 from ?67.00??"",
          ""Choices"": [ ""?51.00"", ""?54.00"", ""?52.00"", ""?53.00"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract ?73.00 from ?95.00??"",
          ""Choices"": [ ""?22.00"", ""?23.00"", ""?25.00"", ""?22.00"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What will you get when you subtract ?24.00 from ?69.00??"",
          ""Choices"": [ ""?44.00"", ""?45.00"", ""?43.00"", ""?42.00"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract ?15.00 from ?98.00??"",
          ""Choices"": [ ""?74.00"", ""?73.00"", ""?83.00"", ""?82.00"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""How many more is 7 plus 2??"",
          ""Choices"": [ ""10 "", ""9"", ""6 "", ""11 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many more is 8 plus 4??"",
          ""Choices"": [ ""10 "", ""19"", ""16 "", ""12 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 6 plus 3??"",
          ""Choices"": [ ""12 "", ""11"", ""6 "", ""9 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 9 plus 5??"",
          ""Choices"": [ ""13 "", ""14"", ""16 "", ""11 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many more is 5 plus 3??"",
          ""Choices"": [ ""7 "", ""9"", ""6 "", ""8 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 4 plus 2??"",
          ""Choices"": [ ""6 "", ""9"", ""7 "", ""8 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""How many more is 10 plus 5??"",
          ""Choices"": [ ""14 "", ""19"", ""16 "", ""15 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 5 plus 4??"",
          ""Choices"": [ ""8 "", ""6"", ""9 "", ""10 "" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""How many more is 4 plus 3??"",
          ""Choices"": [ ""10 "", ""7"", ""6 "", ""9 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many more is 6 plus 4??"",
          ""Choices"": [ ""10 "", ""9"", ""8 "", ""11 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is 9 less than 15??"",
          ""Choices"": [ ""9"", ""10"", ""7"", ""6"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is 6 less than 14??"",
          ""Choices"": [ ""8"", ""10"", ""7"", ""9"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is 8 less than 11??"",
          ""Choices"": [ ""5"", ""3"", ""2"", ""4"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is 8 less than 16??"",
          ""Choices"": [ ""6"", ""9"", ""8"", ""7"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is 9 less than 17??"",
          ""Choices"": [ ""13"", ""8"", ""9"", ""6"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is 7 less than 14??"",
          ""Choices"": [ ""8"", ""7"", ""9"", ""11"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is 9 less than 18??"",
          ""Choices"": [ ""8"", ""7"", ""11"", ""9"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is 9 less than 16??"",
          ""Choices"": [ ""11"", ""8"", ""9"", ""7"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is 3 less than 12??"",
          ""Choices"": [ ""9"", ""7"", ""8"", ""11"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is 5 less than 14??"",
          ""Choices"": [ ""11"", ""9"", ""8"", ""10"" ],
          ""Answer"": 1
        }
      ]
    },
    {
      ""QuestionPool"": [
        {
          ""Question"": ""They had 40 boxes of pasta sauce in storage and received 47 more boxes last month. How many boxes of pasta sauce are there??"",
          ""Choices"": [ ""87"", ""84"", ""85"", ""47"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Jenny got 23 presents for her birthday! Then, her grandmother came and gave her 16 more! How many presents did she have in total??"",
          ""Choices"": [ ""44"", ""39"", ""35"", ""40"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Alex baked 44 cupcakes on Monday and 21 cupcakes on Tuesday. How many cupcakes did he bake in total??"",
          ""Choices"": [ ""65"", ""64"", ""67"", ""66"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""At the park, there were 16 girls and 12 boys. How many children were there in total??"",
          ""Choices"": [ ""30"", ""26"", ""28"", ""32"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Ziel bought 15 lipsticks and 34 lip and cheek tints. How many cosmetics does she have in total??"",
          ""Choices"": [ ""46"", ""44"", ""45"", ""49"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""David bought 2 presents for his children. The prices were $25, and $13. How much did he pay in total??"",
          ""Choices"": [ ""$33"", ""$38"", ""$45"", ""$41"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""At the animal park, there were 14 dogs, and 15 birds. How many animals were there altogether??"",
          ""Choices"": [ ""27"", ""26"", ""28"", ""29"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Anne had 34 marbles and Peter had 35. How many did they have in total??"",
          ""Choices"": [ ""74"", ""67"", ""69"", ""79"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""John’s farm has 72 pigs, and 16 sheep. How many animals altogether??"",
          ""Choices"": [ ""70"", ""88"", ""78"", ""83"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Sally picked 52 flowers on Monday, and 16 flowers on Tuesday. How many flowers did she pick altogether??"",
          ""Choices"": [ ""67"", ""62"", ""64"", ""68"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Peter had 29 pieces of chocolate. He gave away 11. How many did he have left??"",
          ""Choices"": [ ""18"", ""15"", ""14"", ""20"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Wanda baked 37 cookies, but 13 of them were burnt, so she threw them away. How many good cookies did she have??"",
          ""Choices"": [ ""20"", ""24"", ""21"", ""25"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Last month, Alex sold 17 cars. This month he only sold 8. How many more cars did he sell last month??"",
          ""Choices"": [ ""10"", ""8"", ""9"", ""7"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""John owned 26 dogs! 14 of them ran away. How many dogs did he have left??"",
          ""Choices"": [ ""13"", ""12"", ""14"", ""11"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Brianna had 46 pages of homework to complete. She did 15. How many pages did she have left??"",
          ""Choices"": [ ""30"", ""27"", ""29"", ""31"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Peter bought 62 apples, he dropped 31. How many apples did he have left??"",
          ""Choices"": [ ""37"", ""32"", ""34"", ""31"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Josh picked 23 flowers, 13 of them died on the way home. How many flowers did Josh have??"",
          ""Choices"": [ ""10"", ""12"", ""14"", ""11"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""At Sam’s school, there are 90 students. If 30 students were away, how many students were at school??"",
          ""Choices"": [ ""75"", ""60"", ""70"", ""65"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""The local farmer had 47 sheep. Last night, 20 ran away. How many sheep did the farmer have now??"",
          ""Choices"": [ ""22"", ""28"", ""27"", ""26"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Amy had 87 toys. Her mum threw away 14. How many toys did she have now??"",
          ""Choices"": [ ""72"", ""73"", ""74"", ""75"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract 64 from 87??"",
          ""Choices"": [ ""24"", ""23"", ""25"", ""22"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract 32 from 58??"",
          ""Choices"": [ ""24"", ""23"", ""25"", ""26 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What will you get when you subtract 51 from 63??"",
          ""Choices"": [ ""14 "", ""13 "", ""15 "", ""12 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What will you get when you subtract 24 from 38??"",
          ""Choices"": [ ""14 "", ""13 "", ""15 "", ""12 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What will you get when you subtract 33 from 55??"",
          ""Choices"": [ ""24 "", ""22 "", ""25 "", ""22 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract 24 from 65??"",
          ""Choices"": [ ""44 "", ""43 "", ""41 "", ""42 "" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What will you get when you subtract 3 from 57??"",
          ""Choices"": [ ""51 "", ""54 "", ""52 "", ""53 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract 63 from 85??"",
          ""Choices"": [ ""22"", ""23 "", ""25 "", ""22 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What will you get when you subtract 14 from 59??"",
          ""Choices"": [ ""44 "", ""45 "", ""43 "", ""42 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What will you get when you subtract 5 from 88??"",
          ""Choices"": [ ""74 "", ""73 "", ""83 "", ""82 "" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""How many more is 17 than 2??"",
          ""Choices"": [ ""10 "", ""19"", ""16 "", ""11 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many more is 18 than 4??"",
          ""Choices"": [ ""20 "", ""25"", ""26 "", ""22 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 16 than 3??"",
          ""Choices"": [ ""12 "", ""11"", ""16 "", ""19 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many more is 19 than 5??"",
          ""Choices"": [ ""23 "", ""24"", ""26 "", ""21 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many more is 15 than 3??"",
          ""Choices"": [ ""17 "", ""19"", ""16 "", ""18 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What number is 8 less than 14??"",
          ""Choices"": [ ""6 "", ""9"", ""7 "", ""8 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What number is 27 less than 47??"",
          ""Choices"": [ ""24 "", ""19"", ""26 "", ""20 "" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What number is 7 less than 40??"",
          ""Choices"": [ ""38 "", ""33"", ""34 "", ""30 "" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What number is 9 less than 17??"",
          ""Choices"": [ ""10 "", ""8"", ""6 "", ""9 "" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What number is 10 less than 16??"",
          ""Choices"": [ ""6 "", ""9"", ""8 "", ""11 "" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""14 birds were sitting in a tree. 21 more birds flew up to the tree. How many birds were there altogether in the tree??"",
          ""Choices"": [ ""39"", ""40"", ""37"", ""35"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Lucy went to the grocery store. She bought 12 packs of cookies and 16 packs of noodles. How many packs of groceries did she buy in all??"",
          ""Choices"": [ ""28"", ""30"", ""27"", ""29"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Roden went to a pet shop. He bought 15 gold fish, and 3 packages of fish food. How many fish did he buy??"",
          ""Choices"": [ ""15"", ""18"", ""12"", ""14"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""I read 21 pages of my English book yesterday in just 45 minutes. Today, I read 67 pages. What is the total number of pages that I read??"",
          ""Choices"": [ ""86"", ""89"", ""88"", ""87"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Linda has 31 candies. Chloe has 58. How many candies do they have together??"",
          ""Choices"": [ ""77"", ""89"", ""99"", ""66"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Beth has 76 crayons. She gives 25 of them away to Jen. How many crayons does Beth have left??"",
          ""Choices"": [ ""54"", ""51"", ""59"", ""55"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""29 birds were sitting in a tree. 16 of them flew away. How many birds were left sitting in the tree??"",
          ""Choices"": [ ""18"", ""17"", ""11"", ""13"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Cindy's mom baked 41 cookies. Her son ate 6 cookies and then brought them to school for a party. How many cookies did they bring to school altogether??"",
          ""Choices"": [ ""31"", ""38"", ""39"", ""35"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""18 children were riding on the bus. 11 children were dropped by at the first station. How many children left inside the bus??"",
          ""Choices"": [ ""7"", ""9"", ""8"", ""11"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Princess Anna have 36 suitors and 11 of them stop courting in the first week. How many suitors does she still have??"",
          ""Choices"": [ ""21"", ""25"", ""28"", ""30"" ],
          ""Answer"": 1
        }
      ]
    },
    {
      ""QuestionPool"": [
        {
          ""Question"": ""Find the quotient: 16 ÷ 4 =?"",
          ""Choices"": [ ""5"", ""3"", ""4"", ""10"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Find the quotient: 24 ÷ 6 =?"",
          ""Choices"": [ ""2"", ""4"", ""5"", ""10"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the quotient: 30 ÷ 10 =?"",
          ""Choices"": [ ""3"", ""5"", ""18"", ""4"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the quotient: 15 ÷ 5 =?"",
          ""Choices"": [ ""3"", ""10"", ""5"", ""20"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the quotient: 12 ÷ 3 =?"",
          ""Choices"": [ ""15"", ""10"", ""5"", ""4"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Find the quotient: 10 ÷ 2 =?"",
          ""Choices"": [ ""18"", ""5"", ""12"", ""4"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the quotient: 30 ÷ 10 =?"",
          ""Choices"": [ ""2"", ""3"", ""40"", ""5"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the quotient: 20 ÷ 4 =?"",
          ""Choices"": [ ""10"", ""3"", ""5"", ""24"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Find the quotient: 9 ÷ 3 =?"",
          ""Choices"": [ ""4"", ""10"", ""12"", ""3"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Find the quotient: 20 ÷ 2 =?"",
          ""Choices"": [ ""10"", ""22"", ""40"", ""12"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the quotient: 8 ÷ 2 =?"",
          ""Choices"": [ ""4"", ""10"", ""12"", ""5"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the quotient: 25 ÷ 5 =?"",
          ""Choices"": [ ""30"", ""5"", ""31"", ""10"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Find the quotient: 40 ÷ 4 =?"",
          ""Choices"": [ ""10"", ""44"", ""20"", ""43"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Find the quotient: 30 ÷ 5 =?"",
          ""Choices"": [ ""16"", ""35"", ""6"", ""30"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Find the quotient: 6 ÷ 2 =?"",
          ""Choices"": [ ""12"", ""10"", ""8"", ""4"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Number patterns. Complete the missing number of each blank: 20,19, __,17, __. "",
          ""Choices"": [ ""17,16"", ""17,10"", ""18,16”, “15,16"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Number patterns. Complete the missing number of each blank: 15,20,25, __, __. "",
          ""Choices"": [ ""36,40"", ""30,35"", ""35,30”, “35,40"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Number patterns. Complete the missing number of each blank: __, __,9, __,15. "",
          ""Choices"": [ ""3,6,10"", ""7,6,10"", ""5,11,12”, “3,6,12"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Number patterns. Complete the missing number of each blank: 6,12, 18, __, __. "",
          ""Choices"": [ ""26,30"", ""17,20"", ""24,30”, “25,30"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Composing Numbers of the following: 300 + 20 + 5 =? ."",
          ""Choices"": [ ""345"", ""325"", ""355”, “360"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Composing Numbers of the following: 78 + 2 + 10 =? ."",
          ""Choices"": [ ""85"", ""99"", ""90”, “60"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Composing Numbers of the following: 22 + 80 + 8 =? ."",
          ""Choices"": [ ""340"", ""225"", ""115”, “110"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Composing Numbers of the following: 40 + 80 + 5 =? ."",
          ""Choices"": [ ""145"", ""125"", ""355”, “390"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Composing Numbers of the following: 100 + 90 + 2 =? ."",
          ""Choices"": [ ""645"", ""109"", ""782”, “192"" ],
          ""Answer"": 3
        }
      ]
    },
    {
      ""QuestionPool"": [
        {
          ""Question"": ""What is the last day of school in a week?"",
          ""Choices"": [ ""Saturday"", ""Monday"", ""Friday"", ""Sunday"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is the fourth day of the week?"",
          ""Choices"": [ ""Wednesday"", ""Tuesday"", ""Thursday"", ""Monday"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the seventh day of the week?"",
          ""Choices"": [ ""Monday"", ""Sunday"", ""Saturday"", ""Friday"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is the fourth day of school in a week?"",
          ""Choices"": [ ""Tuesday"", ""Thursday"", ""Wednesday"", ""Friday"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is the day between Sunday _ Tuesday?"",
          ""Choices"": [ ""Monday"", ""Tuesday"", ""Wednesday"", ""Saturday"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the day between Wednesday _ Friday"",
          ""Choices"": [ ""Tuesday"", ""Saturday"", ""Sunday"", ""Thursday"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""What is the day between Saturday _ Monday?"",
          ""Choices"": [ ""Friday"", ""Tuesday"", ""Sunday"", ""Wednesday"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""What is the day between Tuesday _ Thursday"",
          ""Choices"": [ ""Wednesday"", ""Thursday"", ""Monday"", ""Friday"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the day between Friday _ Sunday"",
          ""Choices"": [ ""Thursday"", ""Saturday"", ""Monday"", ""Tuesday"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is two days before Friday"",
          ""Choices"": [ ""Tuesday"", ""Wednesday"", ""Thursday"", ""Monday"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""We go to school June to March. That is _ months? "",
          ""Choices"": [ ""11"", ""9"", ""8"", ""10"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""June has _ days "",
          ""Choices"": [ ""31"", ""30"", ""28"", ""29"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""The ninth month is _ "",
          ""Choices"": [ ""October"", ""August"", ""September"", ""November"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""March and May have _ days each "",
          ""Choices"": [ ""30"", ""28"", ""29"", ""31"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""One year has _ months "",
          ""Choices"": [ ""12"", ""11"", ""9"", ""10"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the month before April? "",
          ""Choices"": [ ""February"", ""March"", ""May"", ""April"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is the month after October?"",
          ""Choices"": [ ""September"", ""November"", ""December"", ""October"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""What is the month after January "",
          ""Choices"": [ ""February"", ""December"", ""March"", ""April"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the month before May"",
          ""Choices"": [ ""April"", ""June"", ""March"", ""December"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""What is the month after August"",
          ""Choices"": [ ""September"", ""October"", ""July"", ""January"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""From 11:00 p.m. to 3:00 a.m., there are _ hours"",
          ""Choices"": [ "">"", ""<"", ""4"", ""7"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""From 8:00 a.m. to 11:00 a.m., there are _  hours"",
          ""Choices"": [ ""2"", ""4"", ""3"", ""5"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""From 11:00 a.m., to 1:00 p.m., there are _ hours "",
          ""Choices"": [ ""4"", ""3"", ""2"", ""6"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""From 1:00 p.m., to 6:00 p.m., there are _ hours  "",
          ""Choices"": [ ""5"", ""4"", ""3"", ""7"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""From 1:00 a.m., to 10:00 a.m., there are _ hours "",
          ""Choices"": [ ""9"", ""10"", ""8"", ""7"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""How many minutes are there from 8:00 p.m. to 9:00 p.m.  "",
          ""Choices"": [ ""50"", ""60"", ""55"", ""40"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""How many minutes are there from 9:00 a.m. to 10:15 a.m."",
          ""Choices"": [ ""75"", ""70"", ""65"", ""80"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""How many minutes are there from 2:15 p.m. to 3:00 p.m."",
          ""Choices"": [ ""55"", ""50"", ""40"", ""45"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""How many minutes are there from 5:15 a.m. to 6:00 a.m."",
          ""Choices"": [ ""40"", ""45"", ""50"", ""55"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""There are _ hours in one day. "",
          ""Choices"": [ ""24"", ""23"", ""60"", ""30"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Given 1 liter of milk is equals to 3 glasses of milk. With the given persons' milk consumption per week were: Dominic = 6 glasses, Gabriel = 9 glasses, John Alan = 3 glasses, Aldrin = 5 glasses and Noel = 12 glasses. In one week, who drinks exactly 2 liters of milk? "",
          ""Choices"": [ ""Noel"", ""Gabriel"", ""Aldrin"", ""Dominic"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Given 1 liter of milk is equals to 3 glasses of milk. With the given persons' milk consumption per week were: Dominic = 6 glasses, Gabriel = 9 glasses, John Alan = 3 glasses, Aldrin = 5 glasses and Noel = 12 glasses. In one week, who drinks exactly 1 liter and 2 glasses of milk?  "",
          ""Choices"": [ ""john Alan"", ""Aldrin"", ""Gabriel"", ""Dominic"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Given 1 liter of milk is equals to 3 glasses of milk. With the given persons' milk consumption per week were: Dominic = 6 glasses, Gabriel = 9 glasses, John Alan = 3 glasses, Aldrin = 5 glasses and Noel = 12 glasses. In one week, who drinks exactly 4 liters of milk?  "",
          ""Choices"": [ ""Noel"", ""Aldrin"", ""Dominic"", ""Gabriel"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Given 1 liter of milk is equals to 3 glasses of milk. With the given persons' milk consumption per week were: Dominic = 6 glasses, Gabriel = 9 glasses, John Alan = 3 glasses, Aldrin = 5 glasses and Noel = 12 glasses. In one week, who drinks exactly 3 liters of milk? "",
          ""Choices"": [ ""Noel"", ""John Alan"", ""Gabriel"", ""Aldrin"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Given 1 liter of milk is equals to 3 glasses of milk. With the given persons' milk consumption per week were: Dominic = 6 glasses, Gabriel = 9 glasses, John Alan = 3 glasses, Aldrin = 5 glasses and Noel = 12 glasses. In one week, who drinks exactly 1 liter of milk?  "",
          ""Choices"": [ ""Gabriel"", ""Dominic"", ""Noel"", ""John Alan"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Choose the numeral for each name. twenty-one "",
          ""Choices"": [ ""31"", ""21"", ""11"", ""22"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Choose the numeral for each name. one hundred "",
          ""Choices"": [ ""100"", ""101"", ""110"", ""111"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Choose the numeral for each name. twenty-six "",
          ""Choices"": [ ""36"", ""25"", ""29"", ""26"" ],
          ""Answer"": 3
        },
        {
          ""Question"": ""Choose the numeral for each name. fifty-seven "",
          ""Choices"": [ ""37"", ""47"", ""57"", ""59"" ],
          ""Answer"": 2
        },
        {
          ""Question"": ""Choose the numeral for each name. seventy-nine "",
          ""Choices"": [ ""79"", ""99"", ""69"", ""59"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Which of the choices is an odd number?"",
          ""Choices"": [ ""15"", ""20"", ""2"", ""4"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Which of the choices is an odd number?"",
          ""Choices"": [ ""31"", ""20"", ""22"", ""24"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Which of the choices is an even number?"",
          ""Choices"": [ ""31"", ""32"", ""33"", ""27"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Which of the choices is an odd number?"",
          ""Choices"": [ ""59"", ""42"", ""52"", ""90"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Which of the choices is an even number?"",
          ""Choices"": [ ""11"", ""78"", ""31"", ""35"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Choose Tens or Ones for the place of the marked digit. ->15 "",
          ""Choices"": [ ""Tens"", ""Ones"", ""Hundreths"", ""Thousandths"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Choose Tens or Ones for the place of the marked digit. 97<- "",
          ""Choices"": [ ""Tens"", ""Ones"", ""Hundreths"", ""Thousandths"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Choose Tens or Ones for the place of the marked digit. 13<- "",
          ""Choices"": [ ""Tens"", ""Ones"", ""Hundreths"", ""Thousandths"" ],
          ""Answer"": 1
        },
        {
          ""Question"": ""Choose Tens or Ones for the place of the marked digit. ->18 "",
          ""Choices"": [ ""Tens"", ""Ones"", ""Hundreths"", ""Thousandths"" ],
          ""Answer"": 0
        },
        {
          ""Question"": ""Choose Tens or Ones for the place of the marked digit. ->65 "",
          ""Choices"": [ ""Tens"", ""Ones"", ""Hundreths"", ""Thousandths"" ],
          ""Answer"": 0
        }
      ]
    }
  ]
}";


}

