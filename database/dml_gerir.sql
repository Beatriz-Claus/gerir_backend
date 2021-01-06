--Insere um novo usuário na tabela Usuários passando os campos da tabela
--NEWID() - Gera um UniqueIdentifier para o id
insert into Usuarios (id, nome, email, senha, tipo)
values (NEWID(), 'Fernando Henrique', 'fhguerra@outlook.com', '123456', 'Comum')

--Insere um novo usuário sem passar os campos, somente valores
insert into Usuarios 
values (NEWID(),'Priscila Medeiros', 'primedeiros@gmail.com', '123456', 'Comum')

-- altera todas as linhas
update Usuarios set tipo = 'Comum'  

-- altera somente a linha que deseja usando a clausula where
update Usuarios set nome = 'Fernando Henrique Guerra' where id = 'FB08C077-ED6D-4C56-94DB-A948BA76F4E6'

select * from Usuarios -- * retorna todos os campos
select nome, email from Usuarios

------------------------------------------------------------

insert into Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
values (NEWID(), 'Tarefa 1', 'Descrição da tarefa 1', 'Pessoal', '04-01-2021 18:00:00', 0, 'FB08C077-ED6D-4C56-94DB-A948BA76F4E6')

insert into Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
values (NEWID(), 'Tarefa 2', 'Descrição da tarefa 2', 'Pessoal', '04-01-2021 18:00:00', 0, 'FB08C077-ED6D-4C56-94DB-A948BA76F4E6')

insert into Tarefas (id, titulo, descricao, categoria, dataentrega, status, usuario_id)
values (NEWID(), 'Tarefa 1', 'Descrição da tarefa 1', 'Pessoal', '04-01-2021 18:00:00', 0, '362C3D54-0ED4-4869-8392-34ED81F0820A')

select * from usuarios
select * from tarefas

--inner join

select 
	u.id as id_usuario, 
	u.nome, 
	u.email,
	t.id as id_tarefa,
	t.titulo,
	t.descricao,
	t.categoria,
	t.status,
	t.dataentrega
from usuarios u
inner join tarefas t on t.usuario_id = u.id	
where u.id = 'FB08C077-ED6D-4C56-94DB-A948BA76F4E6'

update Tarefas set status = 1 where id = 'F673FC07-05F5-4E99-AD7D-0886503CAE93'