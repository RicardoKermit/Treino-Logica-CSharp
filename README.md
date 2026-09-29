# C# Logic Practice

Repositório de exercícios práticos de C# focados no desenvolvimento de lógica de programação e resolução estruturada de problemas.

O objectivo não é apenas chegar a código funcional, mas praticar o processo de transformar um requisito numa solução:

```text
Problema
→ Input
→ Output
→ Regras
→ Primeiro passo
→ Estado necessário
→ Implementação
→ Testes
```

## Objectivo

Este projecto foi criado para praticar fundamentos de programação em C#, com especial atenção a:

- decomposição de problemas;
- condições booleanas;
- operadores lógicos;
- ciclos;
- manipulação de listas;
- acumulação de valores;
- procura de elementos;
- validação de dados;
- early returns;
- classes e propriedades;
- tradução de regras de negócio para código.

Os exercícios são resolvidos inicialmente sem LINQ, de forma a tornar explícita a lógica por detrás de cada operação.

## Estrutura dos exercícios

### Nível 1 — Decisões simples

Exercícios focados em condições e operadores booleanos.

#### ClassifyNumber

Classifica um número inteiro como:

- positivo;
- negativo;
- zero.

Conceitos praticados:

- `if`;
- `else if`;
- `else`;
- comparação de valores.

#### CanDrive

Determina se uma pessoa pode conduzir com base na idade e na existência de carta de condução.

Regras:

```text
Age >= 18
AND
HasLicense == true
```

Conceitos praticados:

- operadores booleanos;
- `&&`;
- valores limite.

---

### Nível 2 — Ciclos e acumulação

#### CountPositiveNumbers

Percorre uma lista de números e conta quantos são superiores a zero.

Conceitos praticados:

- `foreach`;
- contador;
- condições dentro de ciclos;
- manutenção de estado durante uma iteração.

#### CalculateTotal

Soma apenas valores superiores a zero.

Conceitos praticados:

- acumuladores;
- filtragem através de condições;
- soma progressiva.

---

### Nível 3 — Objectos e colecções

#### CountPendingOrders

Conta encomendas que:

```text
Total > 100
AND
Paid == false
```

Conceitos praticados:

- listas de objectos;
- acesso a propriedades;
- condições compostas;
- contadores.

#### FindCustomerById

Procura um cliente através do seu identificador.

Se o cliente existir, devolve o objecto `Customer`.

Caso contrário, devolve `null`.

Conceitos praticados:

- procura sequencial;
- comparação de identificadores;
- `return` antecipado;
- nullable reference types.

#### GetAvailableProducts

Cria uma nova lista contendo apenas produtos que:

```text
Active == true
AND
Price > 0
```

Conceitos praticados:

- criação de novas colecções;
- filtragem manual;
- `List<T>.Add`;
- múltiplas condições.

---

### Nível 4 — Validação

#### IsValidOrder

Valida uma encomenda segundo as seguintes regras:

```text
- Tem pelo menos um artigo
- Todos os artigos possuem referência
- Todas as quantidades são superiores a zero
```

A validação termina imediatamente quando é encontrado um artigo inválido.

Conceitos praticados:

- validação;
- early return;
- `string.IsNullOrWhiteSpace`;
- condições de invalidação;
- utilização de `||`.

#### CanAccessSystem

Determina se um utilizador pode aceder a um sistema.

Regras:

```text
IsActive == true
AND
IsBlocked == false
AND
FailedAttempts < 3
```

Conceitos praticados:

- `&&`;
- `!`;
- condições booleanas;
- valores limite.

#### IsEligibleForDiscount

Determina se um cliente é elegível para desconto.

Regra:

```text
Total >= 100
AND
(
    IsPremium == true
    OR
    HasDebt == false
)
```

Conceitos praticados:

- combinação de `&&` e `||`;
- precedência lógica;
- agrupamento através de parênteses.

---

### Nível 5 — Regras de negócio

#### IsValidUser

Valida um utilizador segundo várias condições.

```text
Username preenchido
AND
Age >= 18
AND
Active == true
AND
Blocked == false
```

Conceitos praticados:

- validação de strings;
- múltiplas condições booleanas;
- negação lógica;
- tradução de requisitos para expressões booleanas.

#### CalculateShipping

Calcula os portes de uma encomenda.

Regras:

```text
Total <= 0       → 0
Total >= 100      → 0
Premium customer  → 0
Caso contrário    → 5
```

Conceitos praticados:

- múltiplos caminhos para o mesmo resultado;
- condições alternativas;
- simplificação de regras;
- early return.

#### CalculateOrderTotal

Calcula o valor total dos artigos válidos de uma encomenda.

Um artigo só entra no cálculo quando:

```text
Active == true
AND
Price > 0
AND
Quantity > 0
```

O subtotal de cada artigo é calculado através de:

```text
Price * Quantity
```

e acumulado no total da encomenda.

Conceitos praticados:

- listas de objectos;
- validação;
- cálculo de subtotais;
- acumulação;
- combinação de várias regras.

## Método utilizado

Antes da implementação de cada exercício, o problema é dividido em várias perguntas.

```text
Input:
Que informação recebo?

Output:
O que preciso de devolver?

Rules:
Que condições precisam de ser cumpridas?

First step:
Qual é a primeira operação necessária?

What do I need to store while processing?
Preciso de um contador, acumulador, lista ou nenhum estado?

When does that stored value change?
Em que circunstâncias devo actualizar esse estado?

Can I return early?
Existe alguma situação em que já conheço definitivamente o resultado?
```

Este processo procura evitar escrever código antes de compreender claramente o problema.

## Um padrão importante

Grande parte dos exercícios pode ser reduzida a alguns padrões fundamentais.

### Contar

```text
Percorrer
→ validar
→ incrementar contador
→ devolver contador
```

### Somar

```text
Percorrer
→ validar
→ acumular valor
→ devolver total
```

### Procurar

```text
Percorrer
→ comparar
→ encontrar
→ devolver imediatamente
```

### Filtrar

```text
Criar lista de resultados
→ percorrer
→ validar
→ adicionar elementos válidos
→ devolver lista
```

### Validar

```text
Percorrer
→ procurar condição inválida
→ devolver false imediatamente
→ se nada falhar, devolver true
```

## Pontos de atenção

Durante os exercícios surgiram alguns erros particularmente importantes para o treino da lógica.

### Inversão de condições

Por exemplo, querer validar:

```text
number > 0
```

mas implementar:

```csharp
number <= 0
```

Antes de executar o código, é útil comparar directamente a regra escrita com a expressão implementada.

### Valores limite

Existe diferença entre:

```csharp
value > 100
```

e:

```csharp
value >= 100
```

Os valores exactamente no limite devem fazer parte dos testes.

### Negação de booleanos

Por exemplo:

```csharp
user.Blocked
```

significa que o utilizador está bloqueado.

```csharp
!user.Blocked
```

significa que não está bloqueado.

### Não adicionar regras inexistentes

A implementação deve respeitar os requisitos fornecidos.

Uma validação adicional pode parecer lógica, mas continua a ser uma nova regra de negócio e não deve ser introduzida sem necessidade.

## Testes

Os exercícios utilizam pequenos testes através da consola.

Exemplo:

```csharp
Console.WriteLine(ClassifyNumber(5));
Console.WriteLine(ClassifyNumber(-3));
Console.WriteLine(ClassifyNumber(0));
```

Sempre que existem valores limite, devem ser testados explicitamente.

Por exemplo:

```text
Age >= 18
```

deve incluir pelo menos testes com:

```text
17
18
19
```

O mesmo princípio aplica-se a condições como:

```text
Total > 100
```

onde devem ser testados valores como:

```text
99
100
101
```

## Tecnologias

- C#
- .NET
- Console Application

## Como executar

É necessário ter o .NET SDK instalado.

Clonar o repositório:

```bash
git clone <repository-url>
cd <repository-name>
```

Executar:

```bash
dotnet run
```

Também é possível abrir o projecto através do Visual Studio, Visual Studio Code ou JetBrains Rider.

## Próximos passos

Os próximos exercícios poderão introduzir progressivamente:

- métodos auxiliares;
- excepções;
- enums;
- dicionários;
- LINQ;
- interfaces;
- encapsulamento;
- constructors;
- records;
- manipulação de ficheiros;
- testes unitários;
- princípios de orientação a objectos.

O objectivo continuará a ser o mesmo: compreender primeiro a lógica e só depois implementar a solução.