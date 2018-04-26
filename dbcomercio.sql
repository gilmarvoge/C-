
create database dbcomercio;

use dbcomercio;

create table categoria(
	idcategoria int primary key auto_increment not null,
    nome varchar(50) not null,
    descricao varchar(50) null
    );
 
 create table apresentacao(
	idapresentacao int primary key auto_increment not null,
    nome varchar(50) not null,
   descricao varchar(100) null
 );
 
 create table produto(
	idproduto int primary key auto_increment not null,
    codigo varchar(50) not null,
    nome varchar(50) not null,
    descricao varchar(500) null,
    idcategoria int,
    idapresentacao int,
    foreign key(idcategoria) references categoria(idcategoria),
    foreign key(idapresentacao) references  apresentacao(idapresentacao)
);

 create table fornecedor(
	idfornecedor int primary key auto_increment not null,
    idempresa varchar(50) not null,
    setor_comercial varchar(50) not null,
    tipo_documento varchar(50) not null,
    num_documento varchar(50) not null,
    endereco varchar(50) not null,
    telefone varchar(50) not null,
    email varchar(50) null,
    url varchar(50) null
);

create table funcionario(
	idfuncionario int primary key auto_increment not null,
    nome varchar(50) not null,
    sobrenome varchar(50) not null,
    sexo varchar(1) not null,
	data_nascimento varchar(50) not null,
    num_documento varchar(50) not null,
    endereco varchar(150) not null,
    telefone varchar(50) not null,
    email varchar(50) null,
    acesso varchar(50) not null,
    usuario varchar(50) not null,
    senha varchar(50) not null
    );
    
create table entrada(
	identrada int primary key auto_increment not null,
    idfuncionario int not null,
    idfornecedor int not null,
    data_entrada date not null,
    tipo_comprovante varchar(50) not null,
	serie varchar(4) not null,
    correlativo varchar(7) not null,
    imposto decimal(4,2) null
 );

create table detalhe_entrada(
	iddetalhe_entrada int primary key auto_increment not null,
    identrada int not null,
    idproduto int not null,
    preco_compra decimal(10,2) not null,
    preco_venda decimal(10,2) not null,
	estoque_inicial int not null,
    estoque_atual int not null,
    data_produto date not null,
    data_vencimento date not null
 );

 create table cliente(
	idcliente int primary key auto_increment not null,
    nome varchar(50) not null,
    sobrenome varchar(50) null,
    sexo varchar(1) null,
    tipo_documento varchar(50) null,
    num_documento varchar(50) null,
    endereco varchar(50) null,
    telefone varchar(50) null,
    email varchar(50) null
);

create table venda(
	idvenda int primary key auto_increment not null,
    idcliente int not null,
    idfuncionario int not null,
    data_venda date not null,
    tipo_comprovante varchar(50) not null,
    serie varchar(4) not null,
    correlativo varchar(7) null,
    imposto decimal(4,2) null
 );
 
 create table detalhe_venda(
	iddetalhe_venda int primary key auto_increment not null,
    idvenda int not null,
    iddetalhe_entrada int not null,
    quantidade int not null,
    preco_venda decimal(10,2) not null,
	desconto decimal(10,2)  null
);


 
 