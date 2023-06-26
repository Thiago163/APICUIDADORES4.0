DROP DATABASE cuidadores; 

CREATE DATABASE cuidadores;
USE cuidadores;

CREATE TABLE tipos (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    tipo VARCHAR(20)
);

CREATE TABLE sexos (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    sexo VARCHAR(255)
);

CREATE TABLE usuarios (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    tipos_id INT NOT NULL DEFAULT 1,
    nome VARCHAR(20),
    sobrenome VARCHAR(255),
    data_de_nasc datetime,
    cpf VARCHAR(20),
    celular VARCHAR(255),
    endereco VARCHAR(255),
    cep VARCHAR(10),
    email VARCHAR(128),
    sexos_id INT DEFAULT 2,
    preco double,
    senha VARCHAR(128),
    descricao VARCHAR(500),
    link varchar(400),
    cidade VARCHAR(255),
    estado VARCHAR(255),
    bairro VARCHAR(255),
    Imagem LONGTEXT,
    FOREIGN KEY (sexos_id) REFERENCES sexos(id),
    FOREIGN KEY (tipos_id) REFERENCES tipos(id)
);

CREATE TABLE cuidadores (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    tipos_id INT NOT NULL DEFAULT 1,
    nome VARCHAR(20),
    sobrenome VARCHAR(255),
    data_de_nasc datetime,
    cpf VARCHAR(20),
    celular VARCHAR(255),
    endereco VARCHAR(255),
    cep VARCHAR(10),
    email VARCHAR(128),
    sexos_id INT DEFAULT 2,
    preco double,
    senha VARCHAR(128),
    descricao VARCHAR(500),
    link varchar(400),
    cidade VARCHAR(255),
    estado VARCHAR(255),
    bairro VARCHAR(255),
    Imagem LONGTEXT,
    FOREIGN KEY (sexos_id) REFERENCES sexos(id),
    FOREIGN KEY (tipos_id) REFERENCES tipos(id)
);

CREATE TABLE favoritosusuarios (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    cuidador_id INT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id)
);

CREATE TABLE favoritoscuidadores (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    cuidador_id INT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id)
);

CREATE TABLE estrelascuidador (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    estrela INTEGER,
    cuidador_id INT,
    usuario_id INT,
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
);

CREATE TABLE estrelasusuario (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    estrela INTEGER,
    cuidador_id INT,
    usuario_id INT,
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id)
);

CREATE TABLE recentesusuarios (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    cuidador_id INT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id)
);

CREATE TABLE recentescuidadores (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    cuidador_id INT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (cuidador_id) REFERENCES cuidadores(id)
);

INSERT INTO tipos (id, tipo) VALUES (1, 'Ativo'), (2, 'Inativo'), (3, 'Desenvolvedor');

INSERT INTO sexos (id, sexo) VALUES (1, 'Masculino'), (2, 'Feminino'), (3, 'Não binário'), (4, 'Prefiro não responder');

INSERT INTO usuarios (tipos_id, estado, cidade, bairro, nome, sobrenome, data_de_nasc, cpf, celular, endereco, cep, email, sexos_id, preco, senha, descricao, link, imagem)values
(1, 'São Paulo', 'Santana de Parnaíba', 'Cururuquara', 'Luana', 'Alvez', '2021-11-05', 58854448868, 9289632897, 'estrada dos sonhos', '04522135', 'luana@gmail.com', 2, 10.10, 'pedro1samuel2', 'Meus filhos são uma peste, boa sorte.', 'https://play.google.com/store/', ''),
(3, 'São Paulo', 'Santana de Parnaíba', 'Santana de Parnaíba', 'Desenvolvedor', 'Deste Software', '2023-01-05', 111, 9345727272, 'Indisponível', '11111111', 'criador@gmail.com', 1, 0.0, 'criador', 'Sou um desenvolvedor', 'https://cuidadores.netlify.app/', ''),
(2, 'São Paulo', 'Santana de Parnaíba', 'Cajamar', 'Marcos', 'Solza', '2021-11-05', 68854448868, 9489632897, 'estrada dos tesouros', '06522135', 'marcos@gmail.com', 1, 10.10, 'pedro1samuel2', 'Meus filhos são uma peste, boa sorte.', 'https://play.google.com/store/', '');

INSERT INTO cuidadores (tipos_id, estado, cidade, bairro, nome, sobrenome, data_de_nasc, cpf, celular, endereco, cep, email, sexos_id, preco, senha, descricao, link, imagem)values
(1, 'São Paulo', 'Santana de Parnaíba', 'Cururuquara', 'Luana', 'Alvez', '2021-11-05', 58854448868, 9289632897, 'estrada dos sonhos', '04522135', 'luana@gmail.com', 2, 10.10, 'pedro1samuel2', 'Sou um cuidador excelente.', 'https://play.google.com/store/', ''),
(3, 'São Paulo', 'Santana de Parnaíba', 'Santana de Parnaíba', 'Desenvolvedor', 'Deste Software', '2023-01-05', 111, 9345727272, 'Indisponível', '11111111', 'criador@gmail.com', 1, 0.0, 'criador', 'Sou um desenvolvedor', 'https://cuidadores.netlify.app/', ''),
(2, 'São Paulo', 'Santana de Parnaíba', 'Cururuquara', 'Marcos', 'Solza', '2021-11-05', 68854448868, 9489632897, 'estrada dos tesouros', '06522135', 'marcos@gmail.com', 1, 10.10, 'pedro1samuel2', 'Sou um cuidador excelente.', 'https://play.google.com/store/', '');

INSERT INTO favoritosusuarios (id, usuario_id, cuidador_id) VALUES (1, 2, 1), (2, 1, 2);

INSERT INTO favoritoscuidadores (id, usuario_id, cuidador_id) VALUES (1, 1, 1), (2, 2, 2);

INSERT INTO estrelascuidador (id, estrela, cuidador_id, usuario_id) VALUES (1, 5, 1, 2), (2, 4, 2, 1);

INSERT INTO estrelasusuario (id, estrela, cuidador_id, usuario_id) VALUES (1, 5, 2, 1), (2, 3, 2, 2);

INSERT INTO recentesusuarios (id, usuario_id, cuidador_id) VALUES (1, 2, 3), (2, 1, 2);

INSERT INTO recentescuidadores (id, usuario_id, cuidador_id) VALUES (1, 1, 1), (2, 2, 3);

select ti.tipo, cui.id, cui.nome, cui.sobrenome, cui.data_de_nasc, cui.cpf, cui.celular, cui.endereco, 
cui.cep, cui.email, cui.preco, cui.descricao, cui.imagem, 
cui.link, sx.sexo, cui.cidade, cui.estado, cui.bairro, cui.senha from cuidadores as cui
 join sexos as sx on (cui.sexos_id = sx.id)
 join tipos as ti on (cui.tipos_id = ti.id)
 where tipos_id <> 2;
