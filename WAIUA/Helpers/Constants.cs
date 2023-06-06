﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RestSharp;
using Serilog.Core;

namespace WAIUA.Helpers;

public static class Constants
{
    public static ConcurrentDictionary<string, RestResponse> UrlToBody = new();

    // TODO: Automate this with translations
    public static readonly Dictionary<string, string> GamePodsDictionary = new()
    {
        {"aresqa.aws-rclusterprod-use1-1.dev1-gp-ashburn-1", "Ashburn"}, {"aresriot.aws-mes1-prod.eu-gp-bahrain-1", "Bahrain"}, {"aresriot.aws-mes1-prod.ext1-gp-bahrain-1", "Bahrain"}, {"aresriot.aws-rclusterprod-mes1-1.eu-gp-bahrain-awsedge-1", "Bahrain"}, {"aresriot.aws-rclusterprod-mes1-1.ext1-gp-bahrain-awsedge-1", "Bahrain"}, {"aresriot.aws-rclusterprod-mes1-1.tournament-gp-bahrain-awsedge-1", "Bahrain"}, {"aresriot.aws-rclusterprod-bog1-1.latam-gp-bogota-1", "Bogotá"},
        {"aresriot.aws-rclusterprod-bog1-1.tournament-gp-bogota-1", "Bogotá"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-1", "CMOB 1"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-2", "CMOB 2"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-3", "CMOB 3"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-4", "CMOB 4"}, {"aresriot.mtl-riot-ord2-3.ext1-gp-chicago-1", "Chicago"}, {"aresriot.mtl-riot-ord2-3.latam-gp-chicago-1", "Chicago"},
        {"aresqa.aws-rclusterprod-dfw1-1.dev1-gp-dallas-1", "Dallas"}, {"aresqa.aws-rclusterprod-euc1-1.dev1-gp-frankfurt-1", "Frankfurt"}, {"aresqa.aws-rclusterprod-euc1-1.stage1-gp-frankfurt-1", "Frankfurt"}, {"aresriot.aws-euc1-prod.eu-gp-frankfurt-1", "Frankfurt"}, {"aresriot.aws-euc1-prod.ext1-gp-eu1", "Frankfurt"}, {"aresriot.aws-euc1-prod.ext1-gp-frankfurt-1", "Frankfurt"}, {"aresriot.aws-rclusterprod-euc1-1.ext1-gp-eu1", "Frankfurt"},
        {"aresriot.aws-rclusterprod-euc1-1.tournament-gp-frankfurt-1", "Frankfurt"}, {"aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-1", "Frankfurt 1"}, {"aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-awsedge-1", "Frankfurt 2"}, {"aresriot.aws-ape1-prod.ap-gp-hongkong-1", "Hong Kong"}, {"aresriot.aws-ape1-prod.ext1-gp-hongkong-1", "Hong Kong"}, {"aresriot.aws-rclusterprod-ape1-1.ext1-gp-hongkong-1", "Hong Kong"}, {"aresriot.aws-rclusterprod-ape1-1.tournament-gp-hongkong-1", "Hong Kong"},
        {"aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-1", "Hong Kong 1"}, {"aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-awsedge-1", "Hong Kong 2"}, {"aresriot.mtl-riot-ist1-2.eu-gp-istanbul-1", "Istanbul"}, {"aresriot.mtl-riot-ist1-2.tournament-gp-istanbul-1", "Istanbul"}, {"aresriot.aws-euw2-prod.eu-gp-london-1", "London"}, {"aresriot.aws-rclusterprod-euw2-1.eu-gp-london-awsedge-1", "London"}, {"aresriot.aws-rclusterprod-euw2-1.tournament-gp-london-awsedge-1", "London"},
        {"aresriot.aws-rclusterprod-mad1-1.eu-gp-madrid-1", "Madrid"}, {"aresriot.aws-rclusterprod-mad1-1.tournament-gp-madrid-1", "Madrid"}, {"aresriot.mtl-tmx-mex1-1.ext1-gp-mexicocity-1", "Mexico City"}, {"aresriot.mtl-tmx-mex1-1.latam-gp-mexicocity-1", "Mexico City"}, {"aresriot.mtl-tmx-mex1-1.tournament-gp-mexicocity-1", "Mexico City"}, {"aresriot.mia1.latam-gp-miami-1", "Miami"}, {"aresriot.mia1.tournament-gp-miami-1", "Miami"}, {"aresriot.aws-aps1-prod.ap-gp-mumbai-1", "Mumbai"},
        {"aresriot.aws-rclusterprod-aps1-1.ap-gp-mumbai-awsedge-1", "Mumbai"}, {"aresriot.aws-rclusterprod-aps1-1.tournament-gp-mumbai-awsedge-1", "Mumbai"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-1", "Offline 1"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-2", "Offline 2"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-3", "Offline 3"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-4", "Offline 4"},
        {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-5", "Offline 5"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-6", "Offline 6"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-7", "Offline 7"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-8", "Offline 8"}, {"aresriot.aws-euw3-prod.eu-gp-paris-1", "Paris"}, {"aresriot.aws-rclusterprod-euw3-1.tournament-gp-paris-1", "Paris"}, {"aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-1", "Paris 1"},
        {"aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-awsedge-1", "Paris 2"}, {"aresriot.mtl-ctl-scl2-2.ext1-gp-santiago-1", "Santiago"}, {"aresriot.mtl-ctl-scl2-2.latam-gp-santiago-1", "Santiago"}, {"aresriot.mtl-ctl-scl2-2.tournament-gp-santiago-1", "Santiago"}, {"aresriot.aws-rclusterprod-sae1-1.ext1-gp-saopaulo-1", "Sao Paulo"}, {"aresriot.aws-rclusterprod-sae1-1.tournament-gp-saopaulo-1", "Sao Paulo"}, {"aresriot.aws-sae1-prod.br-gp-saopaulo-1", "Sao Paulo"},
        {"aresriot.aws-sae1-prod.ext1-gp-saopaulo-1", "Sao Paulo"}, {"aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-1", "Sao Paulo 1"}, {"aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-awsedge-1", "Sao Paulo 2"}, {"aresriot.aws-apne2-prod.ext1-gp-seoul-1", "Seoul"}, {"aresriot.aws-apne2-prod.kr-gp-seoul-1", "Seoul"}, {"aresriot.aws-rclusterprod-apne2-1.ext1-gp-seoul-1", "Seoul"}, {"aresriot.aws-rclusterprod-apne2-1.tournament-gp-seoul-1", "Seoul"},
        {"aresriot.aws-rclusterprod-apne2-1.kr-gp-seoul-1", "Seoul 1"}, {"aresriot.aws-apse1-prod.ap-gp-singapore-1", "Singapore"}, {"aresriot.aws-apse1-prod.ext1-gp-singapore-1", "Singapore"}, {"aresriot.aws-rclusterprod-apse1-1.ext1-gp-singapore-1", "Singapore"}, {"aresriot.aws-rclusterprod-apse1-1.tournament-gp-singapore-1", "Singapore"}, {"aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-1", "Singapore 1"}, {"aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-awsedge-1", "Singapore 2"},
        {"aresriot.aws-eun1-prod.eu-gp-stockholm-1", "Stockholm"}, {"aresriot.aws-rclusterprod-eun1-1.tournament-gp-stockholm-1", "Stockholm"}, {"aresriot.aws-rclusterprod-eun1-1.eu-gp-stockholm-1", "Stockholm 1"}, {"aresriot.aws-rclusterprod-eun1-1.eu-gp-stockholm-awsedge-1", "Stockholm 2"}, {"aresriot.aws-apse2-prod.ap-gp-sydney-1", "Sydney"}, {"aresriot.aws-apse2-prod.ext1-gp-sydney-1", "Sydney"}, {"aresriot.aws-rclusterprod-apse2-1.ext1-gp-sydney-1", "Sydney"},
        {"aresriot.aws-rclusterprod-apse2-1.tournament-gp-sydney-1", "Sydney"}, {"aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-1", "Sydney 1"}, {"aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-awsedge-1", "Sydney 2"}, {"aresriot.aws-apne1-prod.ap-gp-tokyo-1", "Tokyo"}, {"aresriot.aws-apne1-prod.eu-gp-tokyo-1", "Tokyo"}, {"aresriot.aws-apne1-prod.ext1-gp-kr1", "Tokyo"}, {"aresriot.aws-apne1-prod.ext1-gp-tokyo-1", "Tokyo"}, {"aresriot.aws-rclusterprod-apne1-1.eu-gp-tokyo-1", "Tokyo"},
        {"aresriot.aws-rclusterprod-apne1-1.ext1-gp-kr1", "Tokyo"}, {"aresriot.aws-rclusterprod-apne1-1.tournament-gp-tokyo-1", "Tokyo"}, {"aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-1", "Tokyo 1"}, {"aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-awsedge-1", "Tokyo 2"}, {"aresqa.aws-usw2-dev.main1-gp-tournament-2", "Tournament"}, {"aresriot.aws-rclusterprod-atl1-1.na-gp-atlanta-1", "US Central (Georgia)"}, {"aresriot.aws-rclusterprod-atl1-1.tournament-gp-atlanta-1", "US Central (Georgia)"},
        {"aresriot.mtl-riot-ord2-3.na-gp-chicago-1", "US Central (Illinois)"}, {"aresriot.mtl-riot-ord2-3.tournament-gp-chicago-1", "US Central (Illinois)"}, {"aresriot.aws-rclusterprod-dfw1-1.na-gp-dallas-1", "US Central (Texas)"}, {"aresriot.aws-rclusterprod-dfw1-1.tournament-gp-dallas-1", "US Central (Texas)"}, {"aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-1", "US East (N. Virginia 1)"}, {"aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-awsedge-1", "US East (N. Virginia 2)"},
        {"aresriot.aws-rclusterprod-use1-1.ext1-gp-ashburn-1", "US East (N. Virginia)"}, {"aresriot.aws-rclusterprod-use1-1.pbe-gp-ashburn-1", "US East (N. Virginia)"}, {"aresriot.aws-rclusterprod-use1-1.tournament-gp-ashburn-1", "US East (N. Virginia)"}, {"aresriot.aws-use1-prod.ext1-gp-ashburn-1", "US East (N. Virginia)"}, {"aresriot.aws-use1-prod.na-gp-ashburn-1", "US East (N. Virginia)"}, {"aresriot.aws-use1-prod.pbe-gp-ashburn-1", "US East (N. Virginia)"},
        {"aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-1", "US West (N. California 1)"}, {"aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-awsedge-1", "US West (N. California 2)"}, {"aresriot.aws-rclusterprod-usw1-1.ext1-gp-na2", "US West (N. California)"}, {"aresriot.aws-rclusterprod-usw1-1.pbe-gp-norcal-1", "US West (N. California)"}, {"aresriot.aws-rclusterprod-usw1-1.tournament-gp-norcal-1", "US West (N. California)"}, {"aresriot.aws-usw1-prod.ext1-gp-na2", "US West (N. California)"},
        {"aresriot.aws-usw1-prod.ext1-gp-norcal-1", "US West (N. California)"}, {"aresriot.aws-usw1-prod.na-gp-norcal-1", "US West (N. California)"}, {"aresriot.aws-rclusterprod-usw2-1.na-gp-oregon-1", "US West (Oregon 1)"}, {"aresriot.aws-rclusterprod-usw2-1.na-gp-oregon-awsedge-1", "US West (Oregon 2)"}, {"aresriot.aws-rclusterprod-usw2-1.pbe-gp-oregon-1", "US West (Oregon)"}, {"aresriot.aws-rclusterprod-usw2-1.tournament-gp-oregon-1", "US West (Oregon)"},
        {"aresriot.aws-usw2-prod.na-gp-oregon-1", "US West (Oregon)"}, {"aresriot.aws-usw2-prod.pbe-gp-oregon-1", "US West (Oregon)"}, {"aresqa.aws-usw2-dev.main1-gp-1", "US West 1"}, {"aresqa.aws-usw2-dev.stage1-gp-1", "US West 1"}, {"aresqa.aws-usw2-dev.main1-gp-4", "US West 2"}, {"aresriot.aws-rclusterprod-waw1-1.eu-gp-warsaw-1", "Warsaw"}, {"aresriot.aws-rclusterprod-waw1-1.tournament-gp-warsaw-1", "Warsaw"}
    };

    public static readonly List<Guid> BeforeAscendantSeasons = new()
    {
        new Guid("0df5adb9-4dcb-6899-1306-3e9860661dd3"),
        new Guid("3f61c772-4560-cd3f-5d3f-a7ab5abda6b3"),
        new Guid("0530b9c4-4980-f2ee-df5d-09864cd00542"),
        new Guid("46ea6166-4573-1128-9cea-60a15640059b"),
        new Guid("fcf2c8f4-4324-e50b-2e23-718e4a3ab046"),
        new Guid("97b6e739-44cc-ffa7-49ad-398ba502ceb0"),
        new Guid("ab57ef51-4e59-da91-cc8d-51a5a2b9b8ff"),
        new Guid("52e9749a-429b-7060-99fe-4595426a0cf7"),
        new Guid("71c81c67-4fae-ceb1-844c-aab2bb8710fa"),
        new Guid("2a27e5d2-4d30-c9e2-b15a-93b8909a442c"),
        new Guid("4cb622e1-4244-6da3-7276-8daaf1c01be2"),
        new Guid("a16955a5-4ad0-f761-5e9e-389df1c892fb"),
        new Guid("97b39124-46ce-8b55-8fd1-7cbf7ffe173f"),
        new Guid("573f53ac-41a5-3a7d-d9ce-d6a6298e5704"),
        new Guid("d929bc38-4ab6-7da4-94f0-ee84f8ac141e"),
        new Guid("3e47230a-463c-a301-eb7d-67bb60357d4f"),
        new Guid("808202d6-4f2b-a8ff-1feb-b3a0590ad79f")
    };

    public static string Platform = "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9";

    public static string AccessToken { get; set; }
    public static string EntitlementToken { get; set; }
    public static string Region { get; set; }
    public static string Shard { get; set; }
    public static string Version { get; set; }
    public static string LocalAppDataPath { get; set; }
    public static Guid Ppuuid { get; set; }
    public static Guid PPartyId { get; set; }
    public static string Port { get; set; }
    public static string LPassword { get; set; }

    public static Logger Log { get; set; }
    // public static RestClient RestClient { get; set; }
}