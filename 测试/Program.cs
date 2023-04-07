//var client = new HttpClient();

////var res = await client.GetStringAsync("https://httpbin.org/get");
////Console.WriteLine(res);

//var response = await client.GetAsync("https://httpbin.org/get");
//Console.WriteLine(response.StatusCode);
//if(response.IsSuccessStatusCode) {
//    Console.WriteLine(response.Content.Headers);
//    Console.WriteLine(await response.Content.ReadAsStringAsync());
//}


using System.Security.Cryptography;
using System.Text;

//string UUID = Guid.NewGuid().ToString();
string UUID = "3f5d82af-5626-4444-8911-ea4fb581993e";
string key = "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl";
Console.WriteLine($"uuid是{UUID}");
var a = MakeMd5(UUID + key);
Console.WriteLine(a);
var b = MakeMd5(a);
Console.WriteLine(b);
string MakeMd5(string t) {
    Console.WriteLine($"要加密的数据:{t}");
    MD5 md5 = MD5.Create();
    byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(t));
    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < res.Length; i++) {
        sb.Append(res[i].ToString("X2"));
    }
    return sb.ToString().ToUpper();

}