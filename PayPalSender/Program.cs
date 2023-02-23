// See https://aka.ms/new-console-template for more information

using PayPalAPISDK;

Console.WriteLine("Hello, World!");
const string clientId = "AfixC4Bq0xQCCQK6Wo5HwPXCdzfSb2rumlhjKtMR-IYHisT_1gcQ9aJofMOuA2FU5jwWEOaiT5_vLgT9";
const string clientSecret = "EPiSekitZfUkoJ3dgcTwnZ_-NRaA8wSl3hoODcrAOlQPNQr4HBohtMtamV2unYaGVn0FClhFkDuCfumv";
var token = new PayPalAuth(clientId, clientSecret).GetToken();

Console.WriteLine(token.token_type);