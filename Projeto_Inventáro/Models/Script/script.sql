CREATE database CTI_TESTE04; 

	USE  CTI_TESTE04;

	/* criação da tabela setor com uma pk e a sigla de cada setor do sesc*/
	CREATE TABLE `tbl_setor`(
	cod_setor INT(2) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome_setor VARCHAR(20) NOT NULL 
);
	/*Criação da tabela usuario com uma pk de controle e sera add futuramente os nomes dos usarios*/
	CREATE TABLE `tbl_usuario`(
    cod_usuario INT(20) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome_usario VARCHAR(50) ,
	fk_setor INT(2) NOT NUll,
    fk_computador INT(30) NOT NULL
);
	/* Criação da tabela tipo_equipamento apenas para controle de normalização da tabela computador*/
	CREATE TABLE `tbl_tipo_equipamento`(
    cod_tipo INT(30) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome_tipo VARCHAR(150) NOT NULL
    );
	/* criação da tabela modelo para completa tabela tipo de equipamento  para controle da normalização da tabela computador*/
    CREATE TABLE `tbl_modelo` (
    cod_modelo INT(30) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome_modelo VARCHAR(150) NOT NULL
    );
    
    /* criação da tabela computação com os componentes nome do computador
    com duas chaves FK para relacionamento da tabela modelo e tipo de equipamento*/
    CREATE TABLE `tbl_computador` (
    cod_computador INT(30) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    nome_computador VARCHAR(100) NOT NULL, 
    fk_tipo INTEGER NOT NULL,
    fk_modelo INTEGER NOT NULL,
    endereco_ip VARCHAR(15) NOT NULL,
    patrimonio_Gabinete INT(10) NOT NULL,
    patrimonio_Monitor INT(10) ,
    ano_aquisicao INT(4) NOT NULL,
    Internet_Liberada bool ,
    fk_setor INT(2)  NOT NULL 
    
    );
    
    
    CREATE TABLE `tbl_login` (
	`id` INT(11) NOT NULL AUTO_INCREMENT,
	`user_name` VARCHAR(50) NOT NULL DEFAULT '0',
	`password` VARCHAR(130) NOT NULL DEFAULT '0',
	`full_name` VARCHAR(120) NOT NULL,
	`refresh_token` VARCHAR(500) NULL DEFAULT '0',
	`refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`),
	UNIQUE `user_name` (`user_name`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;
    
    
    
    
   #ALTERAÇÃO DAS TABELAS ADICIONANDOS  AS  REFERENCIAS DE PK E FK
   
   ALTER TABLE `tbl_usuario` ADD CONSTRAINT Fk_setor
   FOREIGN KEY (fk_setor) REFERENCES `tbl_setor` (cod_setor);
   
	ALTER TABLE `tbl_usuario` ADD CONSTRAINT  Fk_computador
   FOREIGN KEY (fk_computador) REFERENCES `tbl_computador` (cod_computador);
   
   	ALTER TABLE `tbl_computador` ADD CONSTRAINT   Fk_tipo
   FOREIGN KEY ( fk_tipo) REFERENCES `tbl_tipo_equipamento` (cod_tipo);
   
    
   	ALTER TABLE `tbl_computador` ADD CONSTRAINT  Fk_modelo
   FOREIGN KEY (fk_modelo) REFERENCES `tbl_modelo` (cod_modelo);
   
    
   	ALTER TABLE `tbl_computador` ADD CONSTRAINT  Fkk_setor
   FOREIGN KEY (fk_setor) REFERENCES `tbl_setor` (cod_setor);
   


   #inserindo na tabela login
   
   INSERT INTO `tbl_login` (`user_name`, `password`, `full_name`, `refresh_token`, `refresh_token_expiry_time`) VALUES
('bbarros', '24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9', 'Bruno Gonçalve Barros', 'h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=', '2021-11-01 11:49:49');
    
    #inserindo os nomes dos setores na entidade setor
	INSERT INTO `tbl_setor` (nome_setor) VALUES ('DR'),('DPS'),('DC'),('DPJUR'),('SECEX'),('CCM'),('CTI'),('CPO'),('SEATC'),('CGP'),('COB'),('SEALM'),('CAO'),('CCB'),('CTS'),('CCL'),('CCT'),('ESCOLA'),('CLA'),('SEAF'),('CSA'),('SENUT'),('MESA BRASIL'),('CMP'),('SEPAT'),('SETCO'); 
	
    # inserindo os tipo de computadores na  entidade tipo_equipamento
    INSERT INTO tbl_tipo_equipamento (nome_tipo) VALUES ('Microcomputador'),('Notebook');
    
	#inserindo os moodelos de computadores na entidade modelo 
    INSERT INTO tbl_modelo (nome_modelo) VALUES ("Dell OptiPlex Micro 7080"), ('Dell Vostro Small'),('Dell XPS 8940'), ("Dell Intel Pentium Gold"),('Dell Inspiron 3280-AS20P'), ('Dell Vostro 15 3000'),('Dell Inspiron 15 5000');
