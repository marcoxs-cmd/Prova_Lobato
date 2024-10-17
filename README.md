## Lembrar de ajusgtar o banco
### Criar o usuário para acessar o banco
```sql
create user "biblioteca" with encrypted password '123456';
create database "biblioteca";
```

### Dar as permissões necessárias
```sql
GRANT CONNECT, CREATE, TEMPORARY ON DATABASE "biblioteca" to "biblioteca";
alter schema public owner to "biblioteca";
grant usage on schema public to "biblioteca";
grant create on schema public to "biblioteca";

alter default privileges for user "biblioteca" in schema public
    GRANT ALL privileges on Tables to "biblioteca";
alter default privileges for user "biblioteca" in schema public
    grant all privileges on SEQUENCES to "biblioteca";
alter default privileges for user "biblioteca" in schema public
    grant all privileges on functions to "biblioteca";
```