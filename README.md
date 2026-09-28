# Calculadora de Notas

Aplicação console em C# para gerenciamento simplificado das notas de um aluno.
Projeto do checkpoint **CS - CP2: Lógica com Estruturas em C#** (FIAP).

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) 6.0 ou superior

## Como executar

```bash
git clone <url-do-repositorio>
cd CalculadoraNotas
dotnet run
```

## Menu

```
1 - Cadastrar aluno
2 - Lançar notas
3 - Calcular média
4 - Sair
```

O menu permanece ativo até o usuário escolher a opção **4 - Sair**.

## Funcionalidades

| Opção | Método | O que faz |
|---|---|---|
| 1 | `CadastrarAluno()` | Solicita o nome do aluno e rejeita nomes vazios. Ao cadastrar um novo aluno, as notas anteriores são descartadas. |
| 2 | `LancarNotas()` | Lê 3 notas e as guarda em um array. Exige aluno cadastrado. |
| 3 | `CalcularMedia()` | Calcula a média das 3 notas e chama `ExibirSituacao()`. Exige aluno e notas lançadas. |
| - | `ExibirSituacao()` | Mostra a situação do aluno com base na média. |

### Validações

- Opção de menu inválida (letras ou número fora de 1 a 4) exibe aviso e volta ao menu.
- Nome vazio ou só com espaços é recusado.
- Nota não numérica (`abc`, `NaN`, `1e1`) é recusada.
- Nota fora do intervalo de 0 a 10 é recusada.
- Aceita vírgula ou ponto como separador decimal (`8,5` ou `8.5`).
- Impede calcular a média sem aluno cadastrado ou sem notas lançadas.

### Critérios de situação

| Média | Situação |
|---|---|
| >= 7,0 | Aprovado |
| >= 5,0 e < 7,0 | Recuperação |
| < 5,0 | Reprovado |

## Estrutura do código

Todo o código está em `Program.cs`, dividido em métodos `static`:

| Método | Responsabilidade |
|---|---|
| `Main()` | Controla o laço do menu e delega para os demais métodos |
| `ExibirMenu()` | Desenha o menu e mostra o aluno atual |
| `LerOpcaoMenu()` | Lê e valida a opção com `int.TryParse` |
| `CadastrarAluno()` | Cadastro do nome |
| `LancarNotas()` | Controla o lançamento das 3 notas |
| `LerNota()` | Lê uma nota com `double.TryParse` e valida a faixa |
| `CalcularMedia()` | Soma as notas e calcula a média |
| `ExibirSituacao()` | Exibe a situação |
| `ClassificarMedia()` | Retorna "Aprovado", "Recuperação" ou "Reprovado" |

Constantes usadas: `MEDIA_APROVACAO`, `MEDIA_RECUPERACAO`, `NOTA_MINIMA`, `NOTA_MAXIMA` e `QUANTIDADE_NOTAS`.

## Conceitos aplicados

- **Variáveis e operadores:** soma e média das notas.
- **Condicionais:** `if/else` e `switch` no menu.
- **Repetição:** `while` no menu, `for` e `foreach` nas notas.
- **Arrays:** `double[] notas` guarda as 3 notas.
- **Métodos:** lógica separada por responsabilidade, com `Main()` enxuto.
- **Entrada e validação:** `Console.ReadLine()` e `TryParse()`.
- **`break`:** encerra o `switch` e os laços de leitura quando a entrada é válida.
- **`continue`:** volta a pedir o dado quando a entrada é inválida.
- **`return`:** early return para sair cedo quando faltam aluno ou notas, e `return valor` em `LerNota()` e `ClassificarMedia()`.
- **Flag booleana `executando`:** o `break` dentro do `switch` só sai do `switch`, então a flag encerra o `while` do menu.

## Testes realizados

| Entrada | Resultado esperado |
|---|---|
| 7 / 7 / 7 | Média 7,00: **Aprovado** |
| 5 / 5 / 5 | Média 5,00: **Recuperação** |
| 4 / 3 / 2 | Média 3,00: **Reprovado** |
| 8,5 / 6 / 7,5 | Aceita vírgula decimal |
| Nota `abc` | "Entrada inválida!" e pede novamente |
| Nota `NaN` ou `1e1` | "Entrada inválida!" e pede novamente |
| Nota `11` ou `-1` | "Nota fora do intervalo!" e pede novamente |
| Nome vazio | "Nome inválido!" e pede novamente |
| Opção `9` ou `abc` no menu | "Opção inválida!" |
| Opção 2 sem aluno cadastrado | Aviso para cadastrar o aluno |
| Opção 3 antes de lançar notas | Aviso para lançar as notas |
| Lançar notas do aluno A, cadastrar aluno B e escolher opção 3 | Aviso para lançar as notas (notas do A foram descartadas) |

## Histórico de versões

- Estrutura inicial, menu e constantes
- Cadastro de aluno
- Lançamento de notas com validação
- Cálculo de média e situação
- Correção de bugs: rejeição de `NaN` e notação científica, e limpeza das notas ao cadastrar novo aluno

## Autor

Nome: _seu nome_
RM: _seu RM_
