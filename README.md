# WZSISTEMAS.Data.Criptografia

## Sobre

Dá suporte a criptografia de dados em uma aplicação, abstraindo toda a curva de implementação de um provedor de criptografia.

## Criptografia simétrica

A criptografia simétrica permite que seja criptografado e descriptografado dados utilizando uma mesma chave de criptografia, tornando simples o processo de criptografia quando a chave de criptografia ficará somente em um local ou pode ser compartilhada.

### Provedor AES

#### Criptografar

Para utilizar a **criptografia simétrica AES** utilize a classe **ProvedorAes** disponível no namespace **WZSISTEMAS.Data.Criptografia** utilizando o método **Criptografar**.

Abaixo um exemplo de código para criptografar:

```
string aESChave = "digite a chave de criptografia aqui (32 caractéres)";
string aESIV = "digite o vetor de inicialização aqui (16 caractéres)";

WZSISTEMAS.Data.Criptografia.ProvedorAes aes = new WZSISTEMAS.Data.Criptografia.ProvedorAes();

aes.Criptografar(aESChave, aESIV, "texto que será criptografado");
```

> Durante a execução do método as seguintes exceções podem ser disparadas.
> * **WZSISTEMAS.Data.Exceptions.ChaveFormatoException**
>> A chave informada está em um formato inválido. Ela deve ter 32 caractéres.
> * **WZSISTEMAS.Data.Exceptions.IVFormatoException**
>> O vetor de inicialização (IV) informado está em um formato inválido. Ele deve ter 16 caractéres.

#### Descriptografar

Para utilizar a descriptografia simétrica AES utilize a classe **ProvedorAes** disponível no namespace **WZSISTEMAS.Data.Criptografia** utilizando o método **Descriptografar**.

Abaixo um exemplo de código para descriptografar:

```
string aESChave = "digite a chave de descriptografia aqui (32 caractéres)";
string aESIV = "digite o vetor de inicialização aqui (16 caractéres)";

WZSISTEMAS.Data.Criptografia.ProvedorAes aes = new WZSISTEMAS.Data.Criptografia.ProvedorAes();

aes.Descriptografar(aESChave, aESIV, "texto que será descriptografado");
```

> Durante a execução do método as seguintes exceções podem ser disparadas.
> * **WZSISTEMAS.Data.Exceptions.ChaveFormatoException**
>> A chave informada está em um formato inválido. Ela deve ter 32 caractéres.
> * **WZSISTEMAS.Data.Exceptions.IVFormatoException**
>> O vetor de inicialização (IV) informado está em um formato inválido. Ele deve ter 16 caractéres.
> * **System.FormatException**
>> O texto criptografado não é válido, possívelmente ele não está criptografado.
