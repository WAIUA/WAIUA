﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RestSharp;
using Serilog.Core;

namespace WAIUA.Helpers
{
    public static class Constants
    {
        public static string AccessToken { get; set; }
        public static string EntitlementToken { get; set; }
        public static string Region { get; set; }
        public static string Shard { get; set; }
        public static string Version { get; set; }
        public static string LocalAppDataPath { get; set; }
        public static Guid PPUUID { get; set; }
        public static Guid PPartyID { get; set; }
        public static int Port { get; set; }
        public static int LPassword { get; set; }
        public static Logger Log { get; set; }
        public static ConcurrentDictionary<string, RestResponse> UrlToBody = new();
        public static readonly Dictionary<string, string> GamePodsDictionary = new()
        {
            { "aresriot.aws-rclusterprod-mes1-1.eu-gp-bahrain-awsedge-1", "Bahrain" },
            { "aresriot.aws-rclusterprod-mes1-1.ext1-gp-bahrain-awsedge-1", "Bahrain" },
            { "aresriot.aws-rclusterprod-mes1-1.tournament-gp-bahrain-awsedge-1", "Bahrain" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-1", "CMOB 1" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-2", "CMOB 2" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-3", "CMOB 3" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-cmob-4", "CMOB 4" },
            { "aresriot.mtl-riot-ord2-3.ext1-gp-chicago-1", "Chicago" },
            { "aresriot.mtl-riot-ord2-3.latam-gp-chicago-1", "Chicago" },
            { "aresqa.aws-rclusterprod-dfw1-1.dev1-gp-dallas-1", "Dallas" },
            { "aresqa.aws-rclusterprod-usw2-3.dev1-gp-tournament-2", "Esports New" },
            { "aresqa.aws-rclusterprod-usw2-3.dev1-gp-tournament-1", "Esports Old" },
            { "aresqa.aws-rclusterprod-euc1-1.dev1-gp-frankfurt-1", "Frankfurt" },
            { "aresqa.aws-rclusterprod-euc1-1.stage1-gp-frankfurt-1", "Frankfurt" },
            { "aresriot.aws-rclusterprod-euc1-1.ext1-gp-eu1", "Frankfurt" },
            { "aresriot.aws-rclusterprod-euc1-1.tournament-gp-frankfurt-1", "Frankfurt" },
            { "aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-1", "Frankfurt 1" },
            { "aresriot.aws-rclusterprod-euc1-1.eu-gp-frankfurt-awsedge-1", "Frankfurt 2" },
            { "aresriot.aws-rclusterprod-ape1-1.ext1-gp-hongkong-1", "Hong Kong" },
            { "aresriot.aws-rclusterprod-ape1-1.tournament-gp-hongkong-1", "Hong Kong" },
            { "aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-1", "Hong Kong 1" },
            { "aresriot.aws-rclusterprod-ape1-1.ap-gp-hongkong-awsedge-1", "Hong Kong 2" },
            { "aresriot.mtl-riot-ist1-2.eu-gp-istanbul-1", "Istanbul" },
            { "aresriot.mtl-riot-ist1-2.tournament-gp-istanbul-1", "Istanbul" },
            { "aresriot.aws-rclusterprod-euw2-1.eu-gp-london-awsedge-1", "London" },
            { "aresriot.aws-rclusterprod-euw2-1.tournament-gp-london-awsedge-1", "London" },
            { "aresriot.aws-rclusterprod-mad1-1.eu-gp-madrid-1", "Madrid" },
            { "aresriot.aws-rclusterprod-mad1-1.tournament-gp-madrid-1", "Madrid" },
            { "aresriot.mtl-tmx-mex1-1.ext1-gp-mexicocity-1", "Mexico City" },
            { "aresriot.mtl-tmx-mex1-1.latam-gp-mexicocity-1", "Mexico City" },
            { "aresriot.mtl-tmx-mex1-1.tournament-gp-mexicocity-1", "Mexico City" },
            { "aresriot.mia1.latam-gp-miami-1", "Miami" },
            { "aresriot.mia1.tournament-gp-miami-1", "Miami" },
            { "aresriot.aws-rclusterprod-aps1-1.ap-gp-mumbai-awsedge-1", "Mumbai" },
            { "aresriot.aws-rclusterprod-aps1-1.tournament-gp-mumbai-awsedge-1", "Mumbai" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-1", "Offline 1" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-2", "Offline 2" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-3", "Offline 3" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-4", "Offline 4" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-5", "Offline 5" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-6", "Offline 6" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-7", "Offline 7" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-offline-8", "Offline 8" },
            { "aresriot.aws-rclusterprod-euw3-1.tournament-gp-paris-1", "Paris" },
            { "aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-1", "Paris 1" },
            { "aresriot.aws-rclusterprod-euw3-1.eu-gp-paris-awsedge-1", "Paris 2" },
            { "aresriot.mtl-ctl-scl2-2.ext1-gp-santiago-1", "Santiago" },
            { "aresriot.mtl-ctl-scl2-2.latam-gp-santiago-1", "Santiago" },
            { "aresriot.mtl-ctl-scl2-2.tournament-gp-santiago-1", "Santiago" },
            { "aresriot.aws-rclusterprod-sae1-1.ext1-gp-saopaulo-1", "Sao Paulo" },
            { "aresriot.aws-rclusterprod-sae1-1.tournament-gp-saopaulo-1", "Sao Paulo" },
            { "aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-1", "Sao Paulo 1" },
            { "aresriot.aws-rclusterprod-sae1-1.br-gp-saopaulo-awsedge-1", "Sao Paulo 2" },
            { "aresriot.aws-rclusterprod-apne2-1.ext1-gp-seoul-1", "Seoul" },
            { "aresriot.aws-rclusterprod-apne2-1.tournament-gp-seoul-1", "Seoul" },
            { "aresriot.aws-rclusterprod-apne2-1.kr-gp-seoul-1", "Seoul 1" },
            { "aresriot.aws-rclusterprod-apne2-1.kr-gp-seoul-awsedge-1", "Seoul 2" },
            { "aresriot.aws-rclusterprod-apse1-1.ext1-gp-singapore-1", "Singapore" },
            { "aresriot.aws-rclusterprod-apse1-1.tournament-gp-singapore-1", "Singapore" },
            { "aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-1", "Singapore 1" },
            { "aresriot.aws-rclusterprod-apse1-1.ap-gp-singapore-awsedge-1", "Singapore 2" },
            { "aresriot.aws-rclusterprod-eun1-1.tournament-gp-stockholm-1", "Stockholm" },
            { "aresriot.aws-rclusterprod-eun1-1.eu-gp-stockholm-1", "Stockholm 1" },
            { "aresriot.aws-rclusterprod-eun1-1.eu-gp-stockholm-awsedge-1", "Stockholm 2" },
            { "aresriot.aws-rclusterprod-apse2-1.ext1-gp-sydney-1", "Sydney" },
            { "aresriot.aws-rclusterprod-apse2-1.tournament-gp-sydney-1", "Sydney" },
            { "aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-1", "Sydney 1" },
            { "aresriot.aws-rclusterprod-apse2-1.ap-gp-sydney-awsedge-1", "Sydney 2" },
            { "aresriot.aws-rclusterprod-apne1-1.eu-gp-tokyo-1", "Tokyo" },
            { "aresriot.aws-rclusterprod-apne1-1.ext1-gp-kr1", "Tokyo" },
            { "aresriot.aws-rclusterprod-apne1-1.tournament-gp-tokyo-1", "Tokyo" },
            { "aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-1", "Tokyo 1" },
            { "aresriot.aws-rclusterprod-apne1-1.ap-gp-tokyo-awsedge-1", "Tokyo 2" },
            { "aresriot.aws-rclusterprod-atl1-1.na-gp-atlanta-1", "US Central (Georgia)" },
            { "aresriot.aws-rclusterprod-atl1-1.tournament-gp-atlanta-1", "US Central (Georgia)" },
            { "aresriot.mtl-riot-ord2-3.na-gp-chicago-1", "US Central (Illinois)" },
            { "aresriot.mtl-riot-ord2-3.tournament-gp-chicago-1", "US Central (Illinois)" },
            { "aresriot.aws-rclusterprod-dfw1-1.na-gp-dallas-1", "US Central (Texas)" },
            { "aresriot.aws-rclusterprod-dfw1-1.tournament-gp-dallas-1", "US Central (Texas)" },
            { "aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-1", "US East (N. Virginia 1)" },
            { "aresriot.aws-rclusterprod-use1-1.na-gp-ashburn-awsedge-1", "US East (N. Virginia 2)" },
            { "aresriot.aws-rclusterprod-use1-1.ext1-gp-ashburn-1", "US East (N. Virginia)" },
            { "aresriot.aws-rclusterprod-use1-1.pbe-gp-ashburn-1", "US East (N. Virginia)" },
            { "aresriot.aws-rclusterprod-use1-1.tournament-gp-ashburn-1", "US East (N. Virginia)" },
            { "aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-1", "US West (N. California 1)" },
            { "aresriot.aws-rclusterprod-usw1-1.na-gp-norcal-awsedge-1", "US West (N. California 2)" },
            { "aresriot.aws-rclusterprod-usw1-1.ext1-gp-na2", "US West (N. California)" },
            { "aresriot.aws-rclusterprod-usw1-1.pbe-gp-norcal-1", "US West (N. California)" },
            { "aresriot.aws-rclusterprod-usw1-1.tournament-gp-norcal-1", "US West (N. California)" },
            { "aresriot.aws-rclusterprod-usw2-1.na-gp-oregon-1", "US West (Oregon 1)" },
            { "aresriot.aws-rclusterprod-usw2-1.na-gp-oregon-awsedge-1", "US West (Oregon 2)" },
            { "aresriot.aws-rclusterprod-usw2-1.pbe-gp-oregon-1", "US West (Oregon)" },
            { "aresriot.aws-rclusterprod-usw2-1.tournament-gp-oregon-1", "US West (Oregon)" },
            { "aresqa.aws-rclusterprod-usw2-3.dev1-gp-1", "US West 1" },
            { "aresqa.aws-rclusterprod-usw2-3.stage1-gp-1", "US West 1" },
            { "aresqa.aws-rclusterprod-usw2-3.dev1-gp-4", "US West 2" },
            { "aresriot.aws-rclusterprod-waw1-1.eu-gp-warsaw-1", "Warsaw" },
            { "aresriot.aws-rclusterprod-waw1-1.tournament-gp-warsaw-1", "Warsaw" }
        };
    }
}
