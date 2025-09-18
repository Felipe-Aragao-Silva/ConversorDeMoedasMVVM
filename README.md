
# Conversor de Moedas 💱

Este projeto foi desenvolvido com o intuito de possibilitar ao usuário realizar a conversão de moedas entre **Real Brasileiro (BRL)**, **Dólar Americano (USD)** e **Euro (EUR)**.

A aplicação foi construída em **.NET MAUI** (C# 9.0) utilizando a IDE **Visual Studio** e segue a arquitetura **MVVM (Model-View-ViewModel)**, garantindo separação de responsabilidades, melhor organização e manutenção do código.

---

## 🚀 Tecnologias Utilizadas

* **C# 9.0**
* **.NET MAUI**
* **Arquitetura MVVM**
* **Visual Studio**

---

## 📥 Como baixar o projeto

1. Clone este repositório em sua máquina:

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   ```
2. Acesse a pasta do projeto:

   ```bash
   cd seu-repositorio
   ```

---

## ▶️ Como executar

1. Abra o projeto no **Visual Studio**.
2. Certifique-se de que o workload **.NET MAUI** esteja instalado:

   * Vá em **Visual Studio Installer > Workloads > .NET Multi-platform App UI development**.
3. Compile a aplicação usando a opção **Build**.
4. Execute a aplicação clicando em **Run** (ou `F5`) e selecione o emulador/dispositivo desejado (Android, iOS, Windows ou Mac).

---

## 🧑‍💻 Como usar

1. Informe o valor em uma das moedas disponíveis (**BRL**, **USD** ou **EUR**).
2. Escolha a moeda para a qual deseja converter.
3. Clique no botão **Converter**.
4. O resultado será exibido automaticamente.

> 💡 A aplicação usa taxas de conversão **pré-definidas** (ou configuráveis) para realizar o cálculo.

---

## 📂 Estrutura do Projeto (MVVM)

O projeto segue a arquitetura **MVVM**, organizada da seguinte forma:

* **Model** → Representa as entidades e lógica de negócio (ex.: classes para moedas e taxas de câmbio).
* **View** → Interface gráfica da aplicação, criada em **XAML**.
* **ViewModel** → Faz a ligação entre o `Model` e a `View`, utilizando **Data Binding** e **Commands** para atualizar a interface sem acoplamento.

Estrutura de pastas:

```
├── Models
│   └── RateTable.cs
├── ViewModels
│   └──ViewModel.cs
├── Views
│   └── MainPage.xaml
│   └── MainPage.xaml.cs
├── App.xaml
├── App.xaml.cs
```

---

## 📌 Observações

* Para rodar em dispositivos móveis (Android/iOS), é necessário ter os **emuladores configurados** no Visual Studio.
* Também é possível executar a aplicação em **Windows** (WinUI) ou **MacCatalyst**.
* A lógica de conversão pode ser adaptada para consumir uma **API de câmbio em tempo real**, caso desejado.

---

## 📜 Licença

Este projeto está sob a licença **MIT**. Sinta-se à vontade para utilizar, modificar e compartilhar.

---
