#Procedimento mostrar
delimiter $$
CREATE PROCEDURE spmostrar_categoria()
	BEGIN
		SELECT * from categoria ORDER BY idcategoria desc;
 end $$
 
 call spmostrar_categoria()
 
 
 
 #Procedimento buscar nome
 delimiter $$
 CREATE PROCEDURE spbuscar_noome()
	BEGIN
		DECLARE textobuscar VARCHAR (50);
		SELECT * FROM categoria WHERE nome LIKE  CONCAT(textobuscar, '%');
	END $$

CALL spbuscar_noome();

#Procedimento inserir categoria
 delimiter $$
CREATE PROCEDURE spinserir_categoria()  # talvez tenha que passar parametros  OUT myOutParameter INT
	BEGIN
		DECLARE idcategoria int ;
		DECLARE varNome VARCHAR (50);
        DECLARE varDescricao VARCHAR (50);
		INSERT INTO categoria (nome,descricao) VALUES (varNome,varDescricao);
	END $$

#Procedimento EDITAR categoria
 delimiter $$
CREATE PROCEDURE speditar_categoria()  # talvez tenha que passar parametros  OUT myOutParameter INT
	BEGIN
		DECLARE varIdcategoria int ;
		DECLARE varNome VARCHAR (50);
        DECLARE varDescricao VARCHAR (50);
		UPDATE categoria SET nome = varNome, descricao = varDescricao WHERE idcategoria = varIdcategoria;  
	END $$


#Procedimento DELETAR categoria
spinserir_categoria delimiter $$
CREATE PROCEDURE spdeletar_categoria()  # talvez tenha que passar parametros  OUT myOutParameter INT
	BEGIN
		DECLARE varIdcategoria int ;
		DECLARE varNome VARCHAR (50);
        DECLARE varDescricao VARCHAR (50);
		DELETE FROM categoria WHERE idcategoria = varIdcategoria;  
	END $$
