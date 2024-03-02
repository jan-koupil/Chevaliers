using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chevaliers
{
    internal class GameData
    {
        public static Dictionary<int, Place> Knights0()
        {
            new Place(1).AddPath(2);

            new Place(2);
            return Place.PlaceIndex;
        }

        public static Dictionary<int, Place> Knights3()
        {
            Item cloverKey = new("Čtyřlístkový klíč");
            Item eagleKey = new("Orlí klíč");
            Item wolfKey = new("Vlčí klíč");
            Item monkeyKey = new("Opičí klíč");
            Item snakeKey = new("Hadí klíč");
            Item cabinKey = new("Klíč ke kůlně");
            Item food = new("Jídlo");
            Item misa = new("Ryba Míša");
            Item someRing = new("Nějaký prsten");
            Item rope = new("Lano");
            Item ropeHook = new("Hák na laně");
            Item healing = new("Léčivý lektvar");
            Item dice = new("Házecí kostka");
            Item bracelet2 = new("Náramek +2");
            Item shellNecklace = new("Náhrdelník nezranitelnosti +3");

            new Place(0)
                .AddPath(13)
                .AddPath(52)
                .AddPath(143);

            new Place(1)
                .AddPath(147)
                .AddPath(25)
                .AddPath(125)
                .AddPath(new Path(69, "poprvé"));

            new Place(2)
                .AddItem(new Item("Zlatý náramek"))
                .AddPath(180);

            new Place(3)
                .AddPath(207)
                .AddPath(
                    new Path(134)
                        .AddRequirement(cloverKey)
                );

            new Place(4)
                .AddPath(162)
                .AddPath(189);

            new Place(5)
                .AddPath(new Path(82).AddRequirement(eagleKey))
                .AddPath(209);

            new Place(6)
                .AddPath(218)
                .AddPath(new Path(184, "Min. síla 12"));

            new Place(7)
                .AddPath(182)
                .AddPath(15);

            new Place(8)
                .AddPath(112)
                .AddPath(207);

            new Place(9)
                .AddPath(157)
                .AddItem(rope);

            new Place(10)
                .AddPath(104);

            new Place(11)
                .AddPath(199);
            //Todo: zkontrolovat

            new Place(12)
                .AddPath(161);

            new Place(13)
                .AddPath(136)
                .AddPath(91);

            new Place(14)
                .AddPath(88)
                .AddPath(124);

            new Place(15)
                .AddPath(124)
                .AddPath(174);

            new Place(16)
                .AddPath(100)
                .AddPath(207)
                .AddItem(rope);

            new Place(17)
                .AddPath(172)
                .AddPath(129);

            new Place(18)
                .AddPath(173)
                .AddPath(104)
                .AddPath(new Path(196, "Inteligence 15"));

            new Place(19)
                .AddPath(32)
                .AddPath(148);

            new Place(20)
                .AddPath(69)
                .AddItem(food);

            new Place(21)
                .AddPath(176)
                .AddItem(misa);

            new Place(22)
                .AddPath(new Path(92, "15 bodů síly"))
                .AddPath(194)
                .AddPath(54)
                .AddPath(209);

            new Place(23)
                .AddPath(40)
                .AddPath(97);

            new Place(24)
                .AddPath(72)
                .AddPath(15);

            new Place(25)
                .AddEnemy("Had 7/4/4/0")
                .AddPath(30)
                .AddPath(34)
                .AddPath(175);

            new Place(26)
                .AddPath(137);

            new Place(27)
                .AddPath(110)
                .AddPath(214);

            new Place(28)
                .AddPath(146);

            new Place(29, true);

            new Place(30)
                .AddPath(198);

            new Place(31)
                .AddEnemy("Kostlivec 7/5/8/10")
                .AddPath(150)
                .AddPath(145)
                .SetRemark("Vysvětluje ústup 145");


            new Place(32)
                .AddPath(212)
                .AddPath(84);

            new Place(33)
                .AddPath(new Path(73).AddRequirement(eagleKey))
                .AddPath(167);

            new Place(34)
                .AddPath(42)
                .AddPath(83)
                .AddPath(125);

            new Place(35)
                .AddPath(72)
                .AddItem(monkeyKey)
                .SetRemark("Róba -1 hvězda");

            new Place(36)
                .AddItem(snakeKey)
                .AddPath(209);

            new Place(37)
                .AddItem(someRing)
                .AddPath(1);

            new Place(38)
                .AddPath(85);

            new Place(39)
                .AddEnemy("Kostlivec 7/5/8/10")
                .AddPath(150)
                .AddPath(15);

            new Place(40)
                .AddPath(23)
                .AddPath(133);

            new Place(41)
                .AddItem(wolfKey)
                .AddPath(197);

            new Place(42)
                .AddItem(healing)
                .AddPath(34);

            new Place(43)
                .AddPath(16)
                .AddPath(207)
                .AddPath(new Path(5604, "Inteligence 12"));

            new Place(44)
                .AddPath(new Path(5602, "Páže"))
                .AddPath(150)
                .AddPath(64);

            new Place(45)
                .AddEnemy("Kostlivec 11/8/8/10")
                .AddPath(135)
                .AddPath(209);

            new Place(46)
                .AddPath(209)
                .AddPath(150)
                .AddPath(155);

            new Place(47)
                .AddPath(117)
                .AddPath(1);

            new Place(48)
                .AddPath(165);

            new Place(49)
                .AddItem(new Item("Psí helma"))
                .AddPath(209);

            new Place(50)
                .AddPath(108)
                .AddPath(187);

            new Place(51)
                .AddEnemy("Kostlivec 7/5/8/10")
                .AddPath(178);

            new Place(52)
                .AddPath(0);

            new Place(53)
                .AddPath(new Path(217, "Inteligence 12"))
                .AddPath(150)
                .AddPath(93);

            new Place(54)
                .AddPath(66);

            new Place(55)
                .AddPath(83)
                .AddPath(95)
                .AddPath(175);

            new Place(5601)
                .AddPath(167);

            new Place(5602)
                .AddPath(44);

            new Place(5603)
                .AddPath(105);

            new Place(5604)
                .AddPath(43);

            new Place(57)
                .AddPath(15)
                .AddPath(new Path(202).AddRequirement(dice))
                .AddPath(new Path(62, "Síla 12"));

            new Place(58)
                .AddEnemy("Opice, 9/5/8/5")
                .AddPath(75);

            new Place(59)
                .AddItem(bracelet2)
                .AddPath(74);

            new Place(60)
                .AddPath(193)
                .AddPath(69);

            //**// jít s drahokamem na 204
            new Place(61)
                .AddPath(26);

            new Place(62)
                .AddPath(149)
                .AddItem(cloverKey)
                .AddPath(140);

            new Place(63)
                .AddEnemy("Warrior 7/14/20/30")
                .AddPath(102);

            new Place(64)
                .AddItem(new Item("Zlatý podnos"))
                .AddPath(150);

            new Place(65)
                .AddPath(189)
                .AddPath(new Path(179).AddRequirement(cabinKey));

            new Place(66)
                .AddPath(209)
                .AddPath(5);

            new Place(67)
                .AddEnemy("Skeleton 11/8/8/10")
                .AddPath(135)
                .AddPath(209);

            new Place(68)
                .AddPath(57)
                .AddPath(new Path(120, "Obratnost 12"))
                .AddPath(new Path(62, "Síla 12"))
                .AddPath(15);

            new Place(69)
                .AddPath(119)
                .AddPath(1)
                .AddPath(20)
                .AddPath(60);

            new Place(70)
                .AddPath(219);

            new Place(71)
                .AddEnemy("Jaguár 8/4/3/0")
                .AddPath(131)
                .AddPath(55);

            new Place(72)
                .AddPath(186)
                .AddPath(new Path(109, "Obratnost 9").AddRequirement(rope))
                .AddPath(new Path(109, "Obratnost 9").AddRequirement(ropeHook));

            new Place(73)
                .AddPath(101)
                .AddPath(150);

            new Place(74)
                .AddPath(127)
                .AddPath(59);

            new Place(75)
                .AddItem(snakeKey)
                .AddPath(121)
                .AddPath(208);

            new Place(76, true);

            new Place(77)
                .AddPath(114)
                .AddPath(161);

            new Place(78)
                .AddItem(healing)
                .AddPath(209);

            new Place(79)
                .AddPath(150);

            new Place(80)
                .AddEnemy("Tukan 8/4/5/0")
                .AddPath(65);

            new Place(81)
                .AddPath(33);

            new Place(82)
                .AddItem(new Item("Náhrdelník z perel"))
                .AddPath(209);

            new Place(83)
                .AddPath(55)
                .AddPath(139);

            new Place(84)
                .AddPath(159);

            new Place(85)
                .AddPath(190);

            new Place(86)
                .AddPath(75);

            new Place(87)
                .AddPath(209)
                .AddPath(144);

            new Place(88)
                .AddPath(224)
                .AddPath(124);

            new Place(89)
                .AddPath(new Path(113, "50 zlatých"))
                .AddPath(151);

            new Place(90)
                .AddPath(11)
                .AddPath(171);

            new Place(91)
                .AddPath(27);

            new Place(92)
                .AddPath(209);

            new Place(93)
                .AddEnemy("Skeleton 7/5/8/10")
                .AddPath(15)
                .AddPath(150);

            new Place(94)
                .AddPath(195)
                .AddPath(150);

            new Place(95)
                .AddPath(131)
                .AddPath(133);

            new Place(96)
                .AddEnemy("Vlakodlak 10/10/10/20")
                .AddPath(24)
                .AddPath(15);

            new Place(97)
                .AddItem(shellNecklace)
                .AddPath(40);

            new Place(98)
                .AddItem(new Item("Žezlo s orlí hlavou"))
                .AddPath(15)
                .AddPath(150);

            new Place(99)
                .AddPath(200);

            new Place(100)
                .AddPath(8);

            new Place(101)
                .AddPath(215)
                .AddPath(73);

            new Place(102)
                .AddPath(50)
                .AddPath(150);

            new Place(103)
                .AddEnemy("Skeleton 7/5/8/10")
                .AddPath(209)
                .AddPath(36);

            new Place(104)
                .AddPath(175)
                .AddPath(18);

            new Place(105)
                .AddPath(150)
                .AddPath(new Path(5603, "Obratnost 10"))
                .AddPath(19);

            new Place(106)
                .AddPath(151)
                .AddPath(201)
                .AddPath(175);

            new Place(107)
                .AddPath(79);

            new Place(108)
                .AddPath(177);

            new Place(109)
                .AddPath(new Path(35).AddRequirement(wolfKey));

            new Place(110)
                .AddPath(69)
                .AddPath(223);

            new Place(111)
                .AddPath(154)
                .AddPath(183)
                .AddPath(150);

            new Place(112)
                .AddPath(48);

            new Place(113)
                .AddPath(123);

            new Place(114)
                .AddItem(new Item("Skleněný luk"))
                .AddPath(161)
                .AddPath(150);

            new Place(115, true);

            new Place(116)
                .AddPath(96);

            new Place(117)
                .AddItem(cabinKey)
                .AddPath(218)
                .AddPath(47);

            new Place(118)
                .AddPath(197);

            new Place(119)
                .AddPath(69)
                .AddItem(dice)
                .AddItem(rope)
                .AddItem(new Item("Soška"));

            new Place(120)
                .AddPath(149)
                .AddPath(140)
                .AddItem(cloverKey);

            new Place(121)
                .AddPath(147);

            new Place(122)
                .AddPath(38);

            new Place(123)
                .AddPath(147);

            new Place(124)
                .AddPath(new Path(90, "Síla 15"))
                .AddPath(130)
                .AddPath(150);

            new Place(125)
                .AddPath(185)
                .AddPath(34);

            new Place(126)
                .AddItem(new Item("Píšťalka na nápadnost"))
                .AddPath(150);

            new Place(127)
                .AddPath(59)
                .AddPath(63)
                .AddPath(158);

            new Place(128)
                .AddPath(141);

            new Place(129)
                .AddPath(17)
                .AddPath(133);

            new Place(130)
                .AddPath(105)
                .AddPath(171);

            new Place(131)
                .AddPath(17)
                .AddPath(95);

            new Place(132)
                .AddPath(166)
                .AddPath(199);

            new Place(133)
                .AddPath(new Path(113).AddRequirement(food))
                .AddPath(129)
                .AddPath(95);

            new Place(134)
                .AddItem(new Item("Smaragdová tiára"))
                .AddPath(207);

            new Place(135)
                .AddPath(new Path(49).AddRequirement(snakeKey))
                .AddPath(209);

            new Place(136)
                .AddEnemy("Krysa 6/4/4/0")
                .AddPath(169);

            new Place(137)
                .AddPath(31);

            new Place(138)
                .AddPath(207)
                .AddPath(3);

            new Place(139)
                .AddPath(40);

            //klíče - vysvětlení
            new Place(140)
                .AddPath(62)
                .AddPath(120);

            new Place(141)
                .AddEnemy("Skeleton 11/8/8/10")
                .AddPath(81)
                .AddPath(29)
                .AddPath(150);

            new Place(142)
                .AddPath(new Path(46, "Síla / Int 15"))
                .AddPath(155)
                .AddPath(209)
                .AddPath(150);

            new Place(143)
                .AddPath(27);

            new Place(144)
                .AddPath(168);

            new Place(145)
                .AddPath(new Path(70, "5 hvězd"))
                .AddPath(new Path(221, "pod 5 hvězd"));

            new Place(146)
                .AddPath(12)
                .AddPath(150);

            new Place(147)
                .AddPath(188);

            new Place(148)
                .AddItem(new Item("Žlutý kámen"))
                .AddPath(19);

            new Place(149)
                .AddItem(new Item("Montérky"))
                .AddPath(192)
                .AddPath(21);

            new Place(150)
                .AddPath(126)
                .AddPath(216)
                .AddPath(111)
                .AddPath(180)
                .AddPath(28);

            new Place(151)
                .AddPath(106)
                .AddPath(80);

            new Place(152)
                .AddPath(150);

            new Place(153, true);

            new Place(154)
                .AddPath(183)
                .AddPath(150);

            new Place(155)
                .AddPath(74);

            new Place(156)
                .AddPath(210)
                .AddPath(76);

            new Place(157)
                .AddPath(89);

            new Place(158)
                .AddPath(102);

            new Place(159)
                .AddItem(new Item("Tepaný meč"))
                .AddPath(116);

            new Place(160, true); //hepáč

            new Place(161)
                .AddPath(203)
                .AddPath(152)
                .AddPath(150);

            new Place(162)
                .AddPath(188)
                .AddPath(151);

            new Place(163)
                .AddPath(156);

            new Place(164)
                .AddPath(18);

            new Place(165)
                .AddPath(36)
                .AddPath(103);

            new Place(166)
                .AddPath(209);

            new Place(167)
                .AddPath(191)
                .AddPath(5601)
                .AddPath(150);

            new Place(168)
                .AddPath(67)
                .AddPath(45);

            new Place(169)
                .AddPath(218);

            new Place(170)
                .AddPath(149)
                .AddPath(77);

            new Place(171)
                .AddEnemy("Skeleton 7/5/8/10")
                .AddPath(124)
                .AddPath(14);

            new Place(172)
                .AddPath(58);

            new Place(173)
                .AddPath(51)
                .AddPath(104);


            new Place(174)
                .AddPath(118);

            new Place(175)
                .AddPath(106)
                .AddPath(55);

            new Place(176)
                .AddPath(8);

            new Place(177)
                .AddPath(163);

            //Todo: záhada
            new Place(178)
                .AddPath(104);

            new Place(179)
                .AddPath(211)
                .AddPath(65)
                .AddItem(eagleKey);

            new Place(180)
                .AddPath(2)
                .AddPath(53);

            new Place(181)
                .AddPath(219);

            new Place(182)
                .AddItem(healing)
                .AddPath(68);

            new Place(183)
                .AddPath(94)
                .AddPath(128);

            new Place(184, remark: "Zlato a obratnost")
                .AddPath(218);

            new Place(185)
                .AddEnemy("Had 7/4/4/0")
                .AddPath(139);

            new Place(186)
                .AddPath(122);

            new Place(187)
                .AddPath(150)
                .AddPath(145);

            new Place(188)
                .AddEnemy("Opičák 9/5/8/5")
                .AddPath(99);

            new Place(189)
                .AddPath(104);

            new Place(190)
                .AddPath(205)
                .AddPath(15);

            new Place(191)
                .AddPath(73);

            new Place(192)
                .AddItem(healing)
                .AddPath(153)
                .AddPath(149);

            new Place(193)
                .AddPath(69);
            //Todo: Míša 206

            new Place(194, true);

            new Place(195, remark: "+1 int")
                .AddPath(150);

            new Place(196)
                .AddPath(173)
                .AddPath(218);

            new Place(197)
                .AddPath(98)
                .AddPath(15);

            new Place(198)
                .AddEnemy("Medvěd 4/4/4/0")
                .AddPath(10);

            new Place(199)
                .AddPath(166)
                .AddPath(132)
                .AddPath(90);

            new Place(200)
                .AddPath(115)
                .AddPath(61);

            new Place(201)
                .AddPath(71);

            new Place(202)
                .AddPath(170)
                .AddPath(149);

            new Place(203)
                .AddPath(152);

            new Place(204);

            new Place(205)
                .AddPath(107);

            new Place(206)
                .AddItem(new Item("Kouzelný háček"))
                .AddPath(21);

            new Place(207)
                .AddPath(43)
                .AddPath(138)
                .AddPath(8);

            new Place(208)
                .AddPath(123)
                .AddPath(9);

            new Place(209)
                .AddPath(78)
                .AddPath(142)
                .AddPath(87)
                .AddPath(22);

            new Place(210)
                .AddPath(181);

            new Place(211)
                .AddPath(179);

            new Place(212)
                .AddPath(159);

            new Place(213)
                .AddEnemy("Skeleton 7/14/20/30")
                .AddPath(15)
                .AddPath(41);

            new Place(214)
                .AddPath(223)
                .AddPath(69);

            new Place(215)
                .AddItem(new Item("Prsten"))
                .AddPath(101);

            new Place(216)
                .AddPath(new Path(44).AddRequirement(wolfKey))
                .AddPath(150);

            new Place(217)
                .AddPath(39)
                .AddPath(53);

            new Place(218)
                .AddPath(6)
                .AddPath(164)
                .AddPath(117);

            new Place(219)
                .AddPath(160)
                .AddPath(220);

            new Place(220, true);

            new Place(221)
                .AddPath(219);

            new Place(222);

            new Place(223);

            new Place(224);



            return Place.PlaceIndex;
        }
    }
}
