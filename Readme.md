# Desafio Encurtador de URLs

Desafio proposto pela comunidade [Back-End Brasil](https://github.com/backend-br).  
Saiba mais: [Encurtador de URLs](https://github.com/backend-br/desafios/blob/master/url-shortener/PROBLEM.md).
 
---

#### Tecnologias utilizadas:

- C#
- .NET
- ASP.NET
- SQLite

---

## ⚙️ Passo a passo

#### 1 - Clone este repositório.

#### 2 - Execute `dotnet watch run` no terminal dentro da pasta da API.

#### 3 - O Swagger ira abrir no navegador.

## 📨 Requisições

| Método | URL                            | Descrição                       | Corpo da requisição     |
| ------ | ------------------------------ | ------------------------------- | ----------------------- |
| POST   | /v1/shorten-url                | Encurte uma nova URL.           | [JSON](#encurtarurl)    |

---

## 📄 Corpo das requisições

##### <a id="encurtarurl">/shorten-url - Encurtando uma URL.</a>

```json
{
  "url": "https://github.com/"
}
```