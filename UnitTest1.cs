using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace Linq
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            uint count = 50;                // ���������� ��������� � ������
            uint skip = 0;                  // ����� ��������
            string facet = "category";      // ��������� 
            string locate = "ru-ru";        // �� ����� ����� 
            string search = "linq";         // ����� ������ ���� 

            var client = new RestClient("https://docs.microsoft.com/api/search");

            var request = new RestRequest(Method.GET);
            request.Parameters.Add(new Parameter(name: "search", value: "linq", ParameterType.QueryString));
            request.Parameters.Add(new Parameter(name: "local", value: "ru-ru", ParameterType.QueryString));
            request.Parameters.Add(new Parameter(name: "facet", value: "category", ParameterType.QueryString));
            request.Parameters.Add(new Parameter(name: "$skip", value: "0", ParameterType.QueryString));
            request.Parameters.Add(new Parameter(name: "$top", value: "10", ParameterType.QueryString));

            var response = client.Get(request);
            
            var resp = response.Content;

            // ������� ��������������
            var resps = JsonConvert.DeserializeObject<Result>(resp);

            // ���� �� ��������, �� � ���������� � ����!
            foreach (ResultItem result in resps.Results)
            {
                Console.WriteLine(result);
            }
        }
    }
}