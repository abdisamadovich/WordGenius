create database wordgenius_db;

create table words
( 
	id bigint generated always as identity primary key,
	word varchar(50) not null,
	tranlate varchar(50) not null,
	discription text not null,
	sound bytea[],
	is_remember bool,
	created_at timestamp not null,
	update_at timestamp not null
);


create table sentences
(
	id bigint generated always as identity primary key,
	words_id bigint not null references words(id),
	sentence text not null
);


create table results
(
	id bigint generated always as identity primary key,
	words_id bigint not null references words(id),
	step_1 timestamp,
	step_2 timestamp,
	step_3 timestamp
);



