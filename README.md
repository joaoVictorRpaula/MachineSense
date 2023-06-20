# MachineSense

1. Um novo resultado é gerado.
2. O resultado é salvo no banco de dados.
3. O webhook é acionado e envia o resultado para a API de ajuste.
5. A API de ajuste retorna os valores de ajuste calculados para o componente de ajuste caso necessário.
6. O componente de ajuste acessa o arquivo DAT da máquina de usinagem e aplica os valores de ajuste necessários no arquivo.
7. O arquivo DAT é atualizado e a máquina de usinagem usa os novos parâmetros ajustados na próxima peça que usina.

![Use-Case Diagram][Imagens/USE-CASE.png]
