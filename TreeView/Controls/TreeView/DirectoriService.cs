
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TreeView.Controls.TreeView.Models;

namespace TreeView.Controls.TreeView
{
    public class DirectoriService
    {
        public HttpClient httpclient;
        private readonly string Adress;
        private readonly JsonSerializerOptions jsonSerializerOptions;

        public DirectoriService()
        {
            httpclient = new HttpClient();
            Adress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5005" : "https://localhost:7127";
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        }
        public async Task<List<ItemTree>> GetInfoAboutDirecotory()
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return itemTrees;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/TreeView/GetThisDirectoryInfo");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    itemTrees = JsonSerializer.Deserialize<List<ItemTree>>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return itemTrees;
            }
            return itemTrees;
        }

        public async Task<List<ItemTree>> GetInfoAboutDirecotory(string path)
        {
            List<ItemTree> itemTrees = new List<ItemTree>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Console.WriteLine("504");
                return itemTrees;
            }
            try
            {

                HttpResponseMessage response = await httpclient.GetAsync($"{Adress}/TreeView/GetParentInfo?path={path}");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    itemTrees = JsonSerializer.Deserialize<List<ItemTree>>(data, jsonSerializerOptions);
                }
                else
                {
                    Console.WriteLine("202");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return itemTrees;
            }
            return itemTrees;
        }

    }
}
