using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;
using TranslationAPI.Baidu;

namespace TranslateAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var baidu = new BaiduTranslationAPI();
            baidu.Translate(new BaiduTranslationParam() { From="en",To="zh",SourceText="apple"});
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }

    

   

   
}
