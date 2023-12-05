using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private string placaFormatada;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // DONE: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            if(placaIsValid(placa.ToUpper())){
                veiculos.Add(placaFormatada);
                Console.WriteLine("Veículo estacionado com sucesso.");
            }else{
                Console.WriteLine("Placa inválida.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (placaIsValid(placa.ToUpper()) && veiculos.Any(x => x.ToUpper() == placaFormatada.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // DONE: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // DONE: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0;
                horas = Convert.ToInt16(Console.ReadLine());
                valorTotal = precoInicial + precoPorHora*horas;

                // DONE: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placaFormatada} foi removido e o preço total foi de: {valorTotal:c}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // DONE: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public bool placaIsValid(string placa){
            bool condition0 = placa.Length >= 7;

            string letras = placa.Substring(0,3);
            bool condition1 = Regex.IsMatch(letras, @"^[A-Z]+$");

            string hifen = placa.Substring(3,1);
            bool condition2 = Regex.IsMatch(hifen, @"^[-]+$");

            bool condition3, condition4, condition5;
            string numeroIsolado, numeroOuLetra, restanteDaPlaca;
            if(condition2){ //Compatível com usuário colocando hífen ou não
                numeroIsolado = placa.Substring(4,1);
                condition3 = Regex.IsMatch(numeroIsolado, @"^[0-9]+$");

                numeroOuLetra = placa.Substring(5,1); //Compatível com o novo padrão de placas mercosul
                condition4 = Regex.IsMatch(numeroOuLetra, @"^[0-9ABCDEFGHIJ]+$");

                restanteDaPlaca = placa.Substring(6);
                condition5 = Regex.IsMatch(restanteDaPlaca, @"^[0-9]+$");
            }else{
                numeroIsolado = placa.Substring(3,1);
                condition3 = Regex.IsMatch(numeroIsolado, @"^[0-9]+$");

                numeroOuLetra = placa.Substring(4,1); //Compatível com o novo padrão de placas mercosul
                condition4 = Regex.IsMatch(numeroOuLetra, @"^[0-9ABCDEFGHIJ]+$");

                restanteDaPlaca = placa.Substring(5);
                condition5 = Regex.IsMatch(restanteDaPlaca, @"^[0-9]+$");
            }

            if(condition0 &&
                condition1 &&
                condition3 &&
                condition4 &&
                condition5){
                    this.placaFormatada = letras + " - " + numeroIsolado + numeroOuLetra + restanteDaPlaca;
                    return true;
            }else{
                return false;
            }
        }
    }
}
