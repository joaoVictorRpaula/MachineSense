# MachineSense

1. A new ResultData is generated.
2. The ResultData is saved on database.
3. The webhook is triggered and sends the result to the Adjustment_API.
5. The Adjustment_API sends calculated adjustment values for the Adjustment_Component if needed.
6. The Adjustment_Component accesses the machine DAT file and applies the necessary adjusted values in the file.
7. The DAT file is updated and the machine uses the new parameters set in the next machining.

# Use Case Diagram
![Use-Case Diagram](Imagens/USE-CASE.png)

![Functionalities](https://github.com/joaoVictorRpaula/MachineSense/blob/e4c3b9571d2f1c159f9c2d3ca86ce1af3182d550/Imagens/Data%20Gen%20-%20gata%20Gen%20api.png)
![Functionalities](https://github.com/joaoVictorRpaula/MachineSense/blob/08b426700b490af4774aa02a2e8d40c78e784ce1/Imagens/Webhook%20-%20adj%20api.png)
![Functionalities](https://github.com/joaoVictorRpaula/MachineSense/blob/08b426700b490af4774aa02a2e8d40c78e784ce1/Imagens/adj%20component.png)
