using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


int tentativa = 0;

Console.WriteLine("Enter the message to send:");
string message = Console.ReadLine();
Console.WriteLine("Enter the name of the contact:");
string contactName = Console.ReadLine();

// Inicialize o driver do Chrome
IWebDriver driver = new ChromeDriver();

// Navegue para o site do WhatsApp Web
driver.Navigate().GoToUrl("https://web.whatsapp.com/");

// Aguarde o usuário fazer o login no WhatsApp Web
Console.WriteLine("Faça o login no WhatsApp Web e pressione Enter.");
Console.ReadLine();

while (tentativa < 10)
{
    // Encontre o campo de pesquisa e digite o nome do contato para quem você deseja enviar a mensagem
    IWebElement searchField = driver.FindElement(By.ClassName("Er7QU"));
    searchField.SendKeys(contactName);

    // Aguarde o contato ser encontrado
    Thread.Sleep(2000);

    // Selecione o contato encontrado e clique nele para abrir a conversa
    IWebElement contact = driver.FindElement(By.XPath($"//span[@title = '{contactName}']"));
    contact.Click();

    // Aguarde selecionar o contato
    Thread.Sleep(2000);

    // Encontre o campo de entrada de mensagem e digite a mensagem que você deseja enviar
    IWebElement messageField = driver.FindElement(By.CssSelector("#main > footer > div._2lSWV._3cjY2.copyable-area > div > span:nth-child(2) > div > div._1VZX7 > div._3Uu1_ > div > div.fd365im1.to2l77zo.bbv8nyr4.gfz4du6o.ag5g9lrv.bze30y65.kao4egtt")); ;
    messageField.SendKeys(message);

    // Aguarde escrever a mensagem
    Thread.Sleep(2000);

    // Encontre o botão de envio de mensagem e clique nele para enviar a mensagem
    IWebElement sendButton = driver.FindElement(By.XPath($"//span[@data-icon = 'send']"));
    sendButton.Click();

    // Aguarde a mensagem ser enviada
    Thread.Sleep(2000);

    tentativa++;
        }

        // Feche o navegador
        driver.Quit();



