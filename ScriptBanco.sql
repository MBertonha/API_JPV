CREATE SEQUENCE public.seq_usuario
    INCREMENT 1
    START 1
    MINVALUE 1
    MAXVALUE 9223372036854775807
    CACHE 1;
    
    CREATE TABLE public.ge_usuario
(
    seq_usuario integer NOT NULL DEFAULT nextval('seq_usuario'::regclass),
    cpfcliente character varying(15) COLLATE pg_catalog."default" NOT NULL,
    nomecliente character varying(30) COLLATE pg_catalog."default" NOT NULL,
    datanasc date,
    valorrenda numeric,
    CONSTRAINT ge_usuario_pk PRIMARY KEY (seq_usuario)
)