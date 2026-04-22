CREATE TABLE produtos (
    id INTEGER PRIMARY KEY,
    nome TEXT
);

CREATE TABLE estoque (
    id INTEGER PRIMARY KEY,
    produto TEXT,
    quantidade INT,
    validade TEXT,
    temperatura REAL
);

CREATE TABLE logs (
    id INTEGER PRIMARY KEY,
    acao TEXT,
    data TEXT
);
