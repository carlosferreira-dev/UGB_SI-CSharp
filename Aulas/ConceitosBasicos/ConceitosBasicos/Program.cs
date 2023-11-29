using ConceitosBasicos;
using System;

/*/
 * Exercício 1 - Somar números
/*/
int n1 = 20, n2 = 11, result;
Somador soma;
soma = new Somador();
result = soma.Soma(n1, n2);
Console.WriteLine("===== Exercício 1 - Método com retorno =====");
Console.WriteLine($"A soma dos números {n1} + {n2} é: {result}");
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 2 - Converter de metros para milímetros 
/*/
double metros = 10.45;
Console.WriteLine("===== Exercício 2 - Método estático =====");
Console.WriteLine($"A medida de {metros} metros corresponde a {Conversor.MetrosMilimetros(metros)} milímetros");
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 3 - Calcula Aumento - Método estático
/*/
double salario_atual = 1500.00;
double percentual_desconto = 3.67;
Console.WriteLine("===== Exercício 3 - Método estático =====");
Console.WriteLine($"Salário atual: R${salario_atual} \nPercentual de aumento: {percentual_desconto}% \nValor do aumento: R${(CalculaAumento.Aumento(salario_atual, percentual_desconto))} \nSalário final com o aumento: R${Math.Round(salario_atual + (CalculaDesconto.Desconto(salario_atual, percentual_desconto)), 2)}");
Console.WriteLine("============================================\n\n");
/*/
 * Exercício 4 - Calcula Desconto - Método estático
/*/
double valor_atual = 500.50;
double percentual_aumento = 10;
Console.WriteLine("===== Exercício 4 - Método estático =====");
Console.WriteLine($"Valor atual: R${valor_atual} \nPercentual de desconto: {percentual_aumento}% \nValor do desconto: R${(CalculaDesconto.Desconto(valor_atual, percentual_aumento))} \nValor final da mercadoria: R${Math.Round(valor_atual - (CalculaDesconto.Desconto(valor_atual, percentual_aumento)), 2)}");
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 5 - AluguelCarro - Método estático
/*/
int dias_aluguel = 5;
double km_final = 12400.98, km_inicial = 12000;
Console.WriteLine("===== Exercício 5 - Método estático =====");
Console.WriteLine($"Valor da diária: R$95.00 \nValor por KM percorrido: R$0.35 \nKM inicial: {km_inicial} \nKM Final: {km_final} \nValor a ser pago para a Locadora Rosenclever: R${AluguelCarro.Aluguel(dias_aluguel, km_final, km_inicial)}");
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 6 -  Calcular IMC - Método estático
/*/
double altura = 1.77, peso = 78;
double resultado_imc = (CalculaIMC.IMC(altura, peso));
Console.WriteLine("===== Exercício 6 - Método estático =====");
if  (resultado_imc < 18.5){
    Console.WriteLine($"IMC: {resultado_imc} - você está abaixo do peso");
}
else if (resultado_imc >= 18.5 && resultado_imc <= 24.9){
    Console.WriteLine($"IMC: {resultado_imc} - seu peso está ideal, parabéns!");
}
else if (resultado_imc >=25 && resultado_imc <= 29.9){
    Console.WriteLine($"IMC: {resultado_imc} - Você está levemente acima do peso");
}
else if (resultado_imc >= 30 && resultado_imc <= 34.9){
    Console.WriteLine($"IMC: {resultado_imc} - Você está com obesidade grau 1");
}
else if (resultado_imc >= 35 && resultado_imc <= 39.9){
    Console.WriteLine($"IMC: {resultado_imc} - Você está com obesidade grau 2 (severa)");
}
else if (resultado_imc >= 40){
    Console.WriteLine($"IMC: {resultado_imc} - Você está com obesidade grau 3 (mórbida)");
}
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 7 - Cantoneira até número fornecido - Método estático
/*/

/*/
 * Exercício 8 - Tabuada de cada número - Método estático
/*/
int i, cont;
Console.WriteLine("===== Exercício 8 - Método estático =====");
for (i=1; i <=10; i++)
{
    Console.WriteLine($"Tabuada do {i}");
    for (cont = 1; cont <= 10; cont++)
    {
        Console.WriteLine($"{i} * {cont} = {CalculaTabuada.Tabuada(i, cont)}");
    }
    Console.WriteLine("------");
}
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 9 - Múltiplos de 3 entre 0 e 100 - Método estático
/*/
int contador=1;
Console.WriteLine("===== Exercício 9 - Método estático =====");
Console.WriteLine("Mútiplos de 3 entre 0 e 100:");
while (contador <= 100)
{
    if (Multiplosde3.Multiplos(contador))
    {
        Console.WriteLine($"{contador}");
    }
    contador++;
}
Console.WriteLine("============================================\n\n");

/*/
*Exercício 10 - Fatoriais de 1 até 10 - Método estático
/*/
Console.WriteLine("===== Exercício 10 - Método estático =====");
int fatorial = 1;
for (int n = 1; n <= 10; n++)
{
    fatorial = CalculaFatorial.Fatorial(fatorial, n);
    Console.WriteLine($"Fatorial de {n} é {fatorial}");
}
Console.WriteLine("============================================\n\n");

/*/
 * Exercício 12 - Adivinhar número - Método estático
/*/
Console.WriteLine("===== Exercício 12 - Método estático =====");
int tentativas = 10;
Random ran = new Random();
int numero_aleatorio = ran.Next(101), numero_digitado;
Console.WriteLine($"{numero_aleatorio}");
while (tentativas >= 1)
{
    numero_digitado = Convert.ToInt32(Console.ReadLine());
    if (AdivinharNumero.Numero(numero_aleatorio, numero_digitado))
    {
        Console.WriteLine($"Parabéns, você acertou, o número aleatório é: {numero_aleatorio}");
        break;
    }
    else if (tentativas == 2)
    {
        Console.WriteLine("É sua última tentativa!");
    }
    else
    {
        Console.WriteLine($"Você errou, tentativas restantes {tentativas -1}");
    }
    tentativas--;
}
Console.WriteLine("============================================\n\n");