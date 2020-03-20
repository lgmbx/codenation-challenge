using System;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace Codenation {
    class Program {
        static void Main(string[] args) {


            
            //Request http usando a propria biblioteca do c
            string url = "*GET URL*";
            WebRequest request = WebRequest.CreateHttp(url);
            request.Method = "GET";

            //resposta do request
            using (WebResponse response = request.GetResponse()) {

                Stream dados = response.GetResponseStream();
                StreamReader sr = new StreamReader(dados);


                string responseFromServer = sr.ReadToEnd();


                File.WriteAllText(@"*JSON PATH*", responseFromServer);
                Console.WriteLine(responseFromServer);
                Console.ReadKey();
            }

            //Caminho do arquivo json
            string jsonText = File.ReadAllText(@"*JSON PATH*");

            //Desserializa o arquivo .json para uma classe
            RootObject answer = JsonConvert.DeserializeObject<RootObject>(jsonText);

            //Pega o texto cifrado da classe, descriptografa e armazena na variavel decifrado da classe
            string descriptografado = Criptografia.Cripto(answer.cifrado);
            answer.decifrado = descriptografado;

            //Pega o texto decifrado da classe, e criptografa em Sha1, e armazena na variavel da classe
            string sha = Sha1.ShaConvert(answer.decifrado);
            answer.resumo_criptografico = sha;

            //Serializa a classe em uma string json
            //Devolve a string para o arquivo json
            string jsonClass = JsonConvert.SerializeObject(answer);
            File.WriteAllText(@"*JSON PATH*", jsonClass);
            Console.WriteLine(jsonClass);

            //Upload do arquivo modificado - via POST
            //usando API RestSharp
            RestClient client = new RestClient("*POST URL*");
            var requests = new RestRequest(Method.POST);
            requests.AddFile("answer", "*JSON PATH*");
            IRestResponse responses = client.Execute(requests);
            Console.WriteLine(responses.Content);
            

        }

    }
}

