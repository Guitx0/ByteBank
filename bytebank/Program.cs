using System.Globalization;

namespace ByteBank1
{
    public class Program
    {
        public static void ShowMenu(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Clear();
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");

            int option;

            do
            {               
                option = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, senhas, saldos);
                        break;
                    case 4:
                        DetalhesDeUmUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 5:
                        QuantiaArmazenada(cpfs, titulares, saldos, senhas);
                        break;
                    case 6:
                        ManipularConta(cpfs, titulares, senhas, saldos);
                        break;
                }

                Console.WriteLine("----------------------");

            } while (option != 0);

        }
        public static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Insira o cpf do usuário: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Insira o nome do titular: ");
            titulares.Add(Console.ReadLine());
            Console.Write("insira a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("Usuário registrado com sucesso!! Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);
        }
        public static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine("Digite o cpf:");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);


            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }
        public static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentarConta(i, cpfs, titulares, saldos);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas,  saldos);
        }
        public static void ApresentarConta( int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }
        public static string ValidarCLient(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.Write("Informe o seu CPF: ");
            string entradaCpf = Console.ReadLine();
            bool existeCpf = cpfs.Any(cpf => cpf.Equals(entradaCpf));

            while (!existeCpf)
            {
                Console.Write("CPF inválido, insira novamente ou digite SAIR para voltar ao Menu Principal:  ");
                entradaCpf = Console.ReadLine();
                existeCpf = cpfs.Any(cpf => cpf.Equals(entradaCpf));
                if (entradaCpf == "SAIR")
                {
                    ShowMenu(cpfs, titulares, senhas, saldos);
                }
            }
            Console.Write("Digite a senha: ");
            string entradaSenha = Console.ReadLine();
            bool existeSenha = senhas.Any(senha => senha.Equals(entradaSenha));

            while (!existeSenha)
            {
                Console.Write("Senha inválida, insira novamente ou digite SAIR para voltar ao Menu Principal:  ");
                entradaSenha = Console.ReadLine();
                existeSenha = senhas.Any(senha => senha.Equals(entradaSenha)); 
                if (entradaSenha == "SAIR")
                {
                    ShowMenu(cpfs, titulares, senhas, saldos);
                }
            }
            return entradaCpf;
        }
        public static void DetalhesDeUmUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            string cpfClient = ValidarCLient(cpfs, titulares, saldos, senhas);
            int indexClient = cpfs.IndexOf(cpfClient);
            Console.WriteLine($"Nome: {titulares[indexClient]}");
            Console.WriteLine($"CPF: {cpfs[indexClient]}");
            Console.WriteLine($"Saldo: R$ {saldos[indexClient].ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);
        }
        public static void QuantiaArmazenada(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            string cpfClient = ValidarCLient(cpfs, titulares, saldos, senhas);
            int indexClient = cpfs.IndexOf(cpfClient);
            Console.WriteLine($"Saldo: R$ {saldos[indexClient].ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);
        }
        public static void ManipularConta (List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            string entradaCpf = ValidarCLient(cpfs, titulares, saldos, senhas);
            Console.Clear();
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Voltar ao menu anterior");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
            Console.WriteLine();
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Depositar(entradaCpf, cpfs, titulares, senhas, saldos);
                    break;
                case "2":
                    Sacar(entradaCpf, cpfs, titulares, senhas, saldos);
                    break;
                case "3":
                    Transferir(entradaCpf, cpfs, titulares, senhas, saldos);
                    break;
                case "4":
                    ShowMenu(cpfs, titulares, senhas, saldos);
                    break;  
            }
        }
        public static void Transferir(string entradaCpf, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            int indexPagador = cpfs.IndexOf(entradaCpf);
            Console.Write("Informe o CPF do destinatário: ");
            string destCpf = Console.ReadLine();
            int indexDest = cpfs.IndexOf(destCpf);
            while (indexDest == -1)
            {
                Console.WriteLine("CPF inválido, conta não encontrada!");
                Console.Write("Informe um CPF válido: ");
                destCpf = Console.ReadLine();
                indexDest = cpfs.IndexOf(destCpf);
            }
            Console.Write("Digite o valor a ser transferido: R$ ");
            double valorTransf = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            saldos[indexPagador] -= valorTransf;
            saldos[indexDest] += valorTransf;
            Console.WriteLine("Transferência realizada com sucesso!!");
            Console.WriteLine();
            Console.WriteLine($"{titulares[indexPagador]} seu novo saldo é de R$ {saldos[indexPagador].ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);
        }
        public static void Sacar(string entradaCpf, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            int indexClient = cpfs.IndexOf(entradaCpf);
            Console.Write("Informe o valor a ser sacado: R$ ");
            double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            saldos[indexClient] -= valorSaque;
            Console.WriteLine("Saque efetuado com sucesso!!");
            Console.WriteLine();
            Console.WriteLine($"{titulares[indexClient]} seu novo saldo é de R$ {saldos[indexClient].ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);
        }
        public static void Depositar(string entradaCpf, List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            int indexClient = cpfs.IndexOf(entradaCpf);
            Console.Write("Informe o valor a ser depositado: R$ ");
            double valorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            saldos[indexClient] += valorDeposito;
            Console.WriteLine("Depósito realizado com sucesso!!");
            Console.WriteLine();
            Console.WriteLine($"{titulares[indexClient]} seu novo saldo é de R$ {saldos[indexClient].ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao Menu Principal");
            Console.ReadKey();
            ShowMenu(cpfs, titulares, senhas, saldos);

        }
        public static void Main(string[] args)
        {
            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            ShowMenu(cpfs, titulares, senhas, saldos);
        }
    }
}