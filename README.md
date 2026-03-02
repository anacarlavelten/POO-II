# 🏥 Sistema de Gestão de Clínica Médica

Este repositório contém o núcleo de um sistema de gestão de saúde desenvolvido em **C#**, aplicando conceitos avançados de **Programação Orientada a Objetos (POO)** e boas práticas de arquitetura de software.

## 🏗️ Modelagem do Sistema (UML)

Abaixo, detalho como as classes foram estruturadas. Para fins de modelagem, seguimos o padrão de visibilidade UML:
* `+` **Público** (public)
* `-` **Privado** (private)
* `~` **Interno** (internal)

### 1. Classe: `Consulta`
A peça central do sistema, responsável por conectar os atores da clínica.
* **Atributos:**
    * `- _medico : Medico`
    * `- _paciente : Paciente`
    * `- _dataHorario : DateTime`
    * `- _realizada : bool`
    * `+ Compareceu : bool` (Somente leitura)
* **Métodos:**
    * `+ Consulta(medico, paciente, data)` : Construtor com validação de data.
    * `+ RegistrarPresenca() : void`

### 2. Classe: `Paciente` e `Medico`
Entidades fundamentais que representam os usuários e profissionais.
* **Paciente:** Possui `Nome` e `CPF` como propriedades somente leitura.
* **Medico:** Possui `Nome` (leitura) e `CRM` (privado).

### 3. Classe: `HistoricoClinico`
Gerencia a linha do tempo de atendimento.
* **Atributos:**
    * `- _registros : List<string>`
* **Métodos:**
    * `+ AdicionarEntrada(data, observacao) : void`
    * `+ Mostrar() : void`

---

## 🛠️ Decisões de Design e Regras de Negócio

A modelagem priorizou a integridade dos dados através do padrão **Fail-Fast** e do **Encapsulamento**:

### **Encapsulamento Estrito**
Todas as classes utilizam o modificador `internal`, garantindo que a lógica de negócio fique restrita ao projeto atual. Campos sensíveis (como CPF e CRM) são privados e acessados apenas via propriedades seguras.

### **Validações de Domínio**
O sistema não permite estados inconsistentes:
* **Prevenção de Erros Temporais:** O sistema lança uma `ArgumentException` se houver tentativa de agendar uma consulta no passado.
* **Consistência de Dados:** Exames exigem prazos positivos e o histórico clínico rejeita textos vazios.

### **Relacionamentos**


* **Associação:** A classe `Consulta` mantém uma referência a `Medico` e `Paciente`.
* **Dependência:** Métodos que utilizam `DateTime` dependem dessa estrutura externa para carimbos de tempo precisos.

---

## 💻 Tecnologias
* **Linguagem:** C# (.NET)
* **Paradigma:** Orientação a Objetos
* **Padrão de Documentação:** Markdown / UML

---
