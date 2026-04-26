# Sistema de Cadastro
Desenvolvi esse sistema de cadastro para poder praticar meus conhecimentos com Banco de Dados e a arquitetura MVC. É um projeto simples mas objetivo: botar a mão na massa e praticar para consolidar o que eu venho estudando.

Durante o desenvolvimento, implementei um CRUD completo, permitindo criar, ler, atualizar e remover registros. O projeto utiliza o Entity Framework Core para gerenciar a comunicação com o banco de dados. Utilizei o padrão MVC (Model-View-Controller) para garantir a separação de responsabildiades através de controllers, intermediando a lógica entre o usuário e os dados.


## Lista de contatos
Essa é a página de cadastro de contatos, onde existe um botão superior que é responsável por cadastrar um novo usuário. 
Existe também a lista de usuários que já estão cadastrados. Extraímos essa informação através do conceito de paginação dinâmica, 
que busca no Banco de Dados somente a quantidade de contatos exibida por página ao invés de carregar milhares de registros 
de uma só vez. Isso evita a sobrecarga de memória no servidor e garante que a interface do usuário permaneça rápida e fluida, 
independentemente do tamanho do banco de dados.

<table style="width:100%; text-align: center;">
  <tr>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/b5fa9db7-7e4a-4185-ba9e-d7ba21012a59" alt="Legenda da Imagem 1" width="100%"/>
      <br>
      <em>Front-End</em>
    </td>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/437a011f-a458-4386-8e6b-f7a85100bbea" alt="Legenda da Imagem 2" width="100%"/>
      <br>
      <em>Paginação no Back-End</em>
    </td>
  </tr>
</table>

## Botão para cadastrar um novo usuário
Essa é a página que realiza de fato o cadastro de um usuário novo, se todos os dados estiverem preenchidos corretamente
(email válido, número de contato válido e todos os campos preenchidos) nós enviamos essas informações para a controller e adicianamos
ao banco de dados.

<table style="width:100%; text-align: center;">
  <tr>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/20753590-48a1-4289-aa0d-a3e86c74ff3f" alt="Legenda da Imagem 1" width="100%"/>
      <br>
      <em>Front-End</em>
    </td>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/323e6804-2f09-4cac-a6e0-92e97f685fcd" alt="Legenda da Imagem 2" width="100%"/>
      <br>
      <em>Back-End</em>
    </td>
  </tr>
</table>

## Lista de usuários
Essa página permite o gerenciamento de usuários e controle administrativo. A listagem também inclui o recurso de paginação dinâmica, além de um seletor de quantidade de registros por página, o que garante alta performance e rapidez na resposta do banco de dados. Cada usuário possui uma senha que fica registrada no banco de dados, também é registrado a data de cadastro daquele usuário através de um DateTime e um username que funciona como login.


<table style="width:100%; text-align: center;">
  <tr>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/754e1845-89f6-4338-8ef1-aab14c96ff68" alt="Legenda da Imagem 1" width="100%"/>
      <br>
      <em>Lista de Usuários</em>
    </td>
    <td style="width:50%;">
      <img src="https://github.com/user-attachments/assets/9e6f0c07-4e7e-42c5-b96d-c88c56c0ab5b" alt="Legenda da Imagem 2" width="100%"/>
      <br>
      <em>Tela de Login, somente para testar o login e senha</em>
    </td>
  </tr>
</table>



## Tecnologias

* C#
* ASP.NET MVC
* Entity Framework
* HTML
* CSS
* JavaScript
