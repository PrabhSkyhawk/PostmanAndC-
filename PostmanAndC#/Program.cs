using System;
using RestSharp;
using System.Threading.Tasks;
using HelloWorldApplication;
namespace HelloWorldApplication
{ 
    public class Program
    {
        static async Task Main(string[] args)
        {
            var postman = new Postman();
            await postman.ExecuteAllRequests();
        }
    }

    public class Postman
    {
        public async Task ExecuteAllRequests()
        {
            await new GetListOfUsers().Execute();
            await new GetSingleUser().Execute();
            await new GetSingleUserNotFound().Execute();
            await new GetListUnknown().Execute();
            await new GetSingleUnknown().Execute();
            await new GetSingleResourcesNotFound().Execute();
            await new PostCreate().Execute();
            await new PostRegisterSuccessful().Execute();
            await new PostRegisterUnsuccessful().Execute();
            await new PostLoginSuccessful().Execute();
            await new PostLoginUnsuccessful().Execute();
            await new PutUpdate().Execute();
        }
    }

    public class GetListOfUsers:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
            var client = new RestClient(options);
            var request = new RestRequest("/api/users?page=2", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class GetSingleUser:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
            var client = new RestClient(options);
            var request = new RestRequest("/api/users/2", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class GetSingleUserNotFound : Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
            var client = new RestClient(options);
            var request = new RestRequest("/api/users/23", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class GetListUnknown : Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");           
            var client = new RestClient(options);
            var request = new RestRequest("/api/unknown", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class GetSingleUnknown : Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");            
            var client = new RestClient(options);
            var request = new RestRequest("/api/unknown/2", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class GetSingleResourcesNotFound : Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
            var client = new RestClient(options);
            var request = new RestRequest("/api/unknown/23", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PostCreate:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");           
            var client = new RestClient(options);
            var request = new RestRequest("/api/users", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""name"": ""morpheus"",
" + "\n" +
            @"    ""job"": ""leader""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PostRegisterSuccessful:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
           
            var client = new RestClient(options);
            var request = new RestRequest("/api/register", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""email"": ""eve.holt@reqres.in"",
" + "\n" +
            @"    ""password"": ""pistol""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PostRegisterUnsuccessful:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
           
            var client = new RestClient(options);
            var request = new RestRequest("/api/register", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""email"": ""sydney@fife""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PostLoginSuccessful:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
           
            var client = new RestClient(options);
            var request = new RestRequest("/api/login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""email"": ""eve.holt@reqres.in"",
" + "\n" +
            @"    ""password"": ""cityslicka""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PostLoginUnsuccessful:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
           
            var client = new RestClient(options);
            var request = new RestRequest("/api/login", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""email"": ""peter@klaven""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }

    public class PutUpdate:Postman
    {
        public async Task Execute()
        {
            var options = new RestClientOptions("https://reqres.in");
            
            var client = new RestClient(options);
            var request = new RestRequest("/api/users/2", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""name"": ""morpheus"",
" + "\n" +
            @"    ""job"": ""zion resident""
" + "\n" +
            @"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}
