create table usuario(
    id int(11) PRIMARY KEY AUTO_INCREMENT NOT null,
    cedula varchar(11),
    nombres varchar  (40),
    apellidos varchar (30),
    celular varchar (30),
    direccion varchar (200),
    created datetime,
    modified datetime,
    latitud float,
    longitud float,
    enable  varchar(6),
    email varchar (50),
    password varchar (50)
  
);

create table casa(
    id int (11) PRIMARY key AUTO_INCREMENT not null,
    direccion varchar (200),
    latitud float,
    longitud float,
    telefono varchar(15),
    usuario_id int (11) ,
    FOREIGN key (usuario_id) references usuario(id) on delete CASCADE
    
);

create table cilindro_gas(
    id int (11) PRIMARY key AUTO_INCREMENT not null,
    color varchar (10),
    detalle varchar (50),
	direccion_ip varchar(20),
    casa_id int (11),
    FOREIGN key (casa_id) REFERENCES casa(id) on delete cascade
    
);
create table pedidos_generales(
    id int (11) PRIMARY key AUTO_INCREMENT,
    fecha date,
    hora time,
    estado varchar (6),
    usuario_id int (11),
    FOREIGN key (usuario_id) REFERENCES usuario(id)on delete CASCADE
    

);

create table distribuidor(
    id int(11) PRIMARY KEY AUTO_INCREMENT NOT null,
    cedula varchar(11),
    nombres varchar  (40),
    apellidos varchar (30),
    celular varchar (30),
    direccion varchar (200),
    created datetime,
    modified datetime,
    latitud float,
    longitud float,
    enable  varchar(6),
    email varchar (50),
    password varchar (50)
  
);
create table pedidos(
    id int (11) PRIMARY key AUTO_INCREMENT,
    fecha date,
    hora time,
    estado varchar (6),
    calificacion_usuario varchar(6),
    calificacion_distribuidor varchar (6),
    usuario_id int (11),
    distribuidor_id int (11),
    
    FOREIGN key (usuario_id) REFERENCES usuario(id)on delete CASCADE,
    FOREIGN key (distribuidor_id) REFERENCES distribuidor(id)on delete CASCADE
    

);
create table calificacion_usuario(
    id int (20) PRIMARY key AUTO_INCREMENT not null ,
    valor int (2),
    fecha date,
    hora time,
    usuario_id int (11),
    foreign key (usuario_id) REFERENCES usuario(id) on delete cascade
);
create table calificacion_distribuidor(
    id int (20) PRIMARY key AUTO_INCREMENT not null ,
    valor int (2),
    fecha date,
    hora time,
    distribuidor_id int (11),
    foreign key (distribuidor_id) REFERENCES distribuidor(id) on delete cascade
);