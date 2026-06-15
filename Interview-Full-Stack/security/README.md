# Security

## Some Concepts

### Cross-Origin Resource Sharing (CORS)

<p align="center">
  <img src="./img/CORS.jpeg?raw=true">
</p>

### Hashing password and salt

When creating the user for the first time, the database doesn't store the actual password. 

<p align="center">
  <img src="./img/hashpasswordandsalt.PNG?raw=true">
</p>

To validate the login:

- the application get the password (provided by the user) and the salt (stored in the database using user identification like e-mail)
- the application hash these password and salt and validate with the hash stored in the database

## Most common attacks:

Injection Attacks

Broken Authentication

Sensitive Data Exposure

XML External Entities

Broken Access Control

Security Misconfiguration

Cross-Site Scripting (XSS)

Insecure Deserialization

Using Components With Known Vulnerabilities

Insufficient Logging and Monitoring

# Cryptography

## Encryption

Encryption is masking or hiding the data by changing the format so that it�s unreadable or indecipherable unless you have the means to decrypt it, so the data remains in place but gets scrambled or hidden.

### Symmetric encryption

- Encrypter, and decrypter � need access to the same key.
- The tricky part is how to store the key and make it available only to the software that needs it.

<p align="center">
  <img src="./img/SymmetricEncryption.PNG?raw=true">
</p>

### Asymmetric encryption

- Uses public and private keys to encrypt and decrypt data.
- Either of the keys can be used to encrypt a message; the opposite key from the one used to encrypt the message is used for decryption.

<p align="center">
  <img src="./img/AsymmetricEncryption.PNG?raw=true">
</p>

## Hash 

- Hashing is used only to verify data
- The same input will always produce the same output
- It�s impossible to reverse it back to the original data
- Given knowledge of only the hash, it�s infeasible to create another string of data that will create the same hash 

<p align="center">
  <img src="./img/Hashing.PNG?raw=true">
</p>

## Token

Tokenization is a process where one tries not to possess the data. It�s a proxy to sensitive information with equivalent non-sensitive information which is the token. In the case of merchants using credit card numbers, instead of encrypting the information one stores it and assigns a key. Just think of it as a vault.

<p align="center">
  <img src="./img/Token.PNG?raw=true">
</p>

## JWT

Json Web Tokens are a stateless solution for authentication. So there is no need to store any session state on the server

- Assuming we already have a registered user in our database, the user will make a login request. 
- If the user exists and if the password is correct, the application will generate a unique JWT
- The token is created using a secret string that is stored on a server. 
- The server then sends that JWT back to the client which will store it either in a cookie or in local storage.

<p align="center">
  <img src="./img/JWT2.png?raw=true">
</p>

- So the server does in fact not know which user is actually logged in, but of course, the user knows that he's logged in because he has a valid Json Web Token which is a bit like a passport to access protected parts of the application.
- Then, each time a user wants to access a protected route like his user profile data, for example. He sends his Json Web Token along with a request, so it's a bit like showing his passport to get access to that route.
- All this communication must happen over https to prevent that anyone can get access to passwords or JWT

<p align="center">
  <img src="./img/JWT3.png?raw=true">
</p>

- JWT has a header, a payload and a signature
- Header and payload must not store any sensitive data


<p align="center">
  <img src="./img/JWT4.png?raw=true">
</p>

- The signature is created using the header, the payload, and the secret that is saved on the server.
- Once the JWT is received on the server in a protected route, the verification will take its header and payload, and together with the secret that is still saved on the server, it creates a test signature.
- If the test signature is the same as the original signature, then it means that the payload and the header have not been modified.

<p align="center">
  <img src="./img/JWT1.png?raw=true">
</p>

## References:

https://peter-chang.medium.com/review-3-main-types-of-encryption-hash-symmetric-asymmetric-tutorial-example-understand-5e57c290324c

https://www.c-sharpcorner.com/article/encryption-and-decryption-using-a-symmetric-key-in-c-sharp/

https://www.c-sharpcorner.com/article/implement-symmetric-and-asymmetric-cryptography-algorithms-with-c-sharp/

https://stackoverflow.com/questions/27301557/if-you-can-decode-jwt-how-are-they-secure

https://www.youtube.com/watch?v=rWHvp7rUka8&list=PLyqga7AXMtPPuibxp1N0TdyDrKwP9H_jD&ab_channel=F5DevCentral
