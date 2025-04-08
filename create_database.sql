--create database plannerA_db;
--CREATE SCHEMA test;

CREATE TABLE table_persons(
    person_id SERIAL NOT NULL PRIMARY KEY,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    patronymic TEXT NOT NULL,
    date_of_birth DATE NOT NULL
);

CREATE TABLE table_departments(
    name TEXT NOT NULL PRIMARY KEY,
    leader_id INTEGER REFERENCES table_persons(person_id),
    description TEXT
);

CREATE TABLE table_workers(
    worker_id SERIAL NOT NULL PRIMARY KEY,
    person_id INTEGER NOT NULL REFERENCES table_persons(person_id),
    specialization TEXT NOT NULL,
    date_of_hire DATE NOT NULL,
    date_of_separation DATE,
    education TEXT,
    date_of_education_end DATE,
    department TEXT NOT NULL REFERENCES table_departments(name),
    salary MONEY NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE table_clients(
    name TEXT NOT NULL PRIMARY KEY,
    address TEXT NOT NULL,
    phone TEXT NOT NULL,
    email TEXT,
    manager_id INTEGER NOT NULL REFERENCES table_workers(worker_id)
);

CREATE TABLE table_orders(
    order_id SERIAL NOT NULL PRIMARY KEY,
    name TEXT NOT NULL,
    client TEXT REFERENCES table_clients(name),
    date_start DATE NOT NULL,
    date_end_plan DATE NOT NULL,
    date_end DATE,
    total_cost MONEY NOT NULL,
    description TEXT
);

CREATE TABLE table_equipments(
    equipment_id SERIAL NOT NULL PRIMARY KEY,
    name TEXT NOT NULL,
    type TEXT NOT NULL,
    model TEXT,
    manufacturer TEXT,
    description TEXT,
    price MONEY NOT NULL,
    date_of_purchase DATE NOT NULL,
    department TEXT REFERENCES table_departments(name),
    is_active BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE table_items(
    name TEXT NOT NULL PRIMARY KEY,
    date_of_produce DATE,
    parameters TEXT,
    price MONEY NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE table_subitems(
    subitem_id SERIAL NOT NULL PRIMARY KEY,
    item TEXT NOT NULL REFERENCES table_items(name),
    parent_item TEXT NOT NULL REFERENCES table_items(name),
    quantity INTEGER NOT NULL             
);

CREATE TABLE table_items_of_order(
    ioo_id SERIAL NOT NULL PRIMARY KEY,
    order_id INTEGER REFERENCES table_orders(order_id),
    item TEXT REFERENCES table_items(name),
    quantity INTEGER NOT NULL,
    cost MONEY NOT NULL
);

CREATE TABLE table_operations(
    name TEXT NOT NULL PRIMARY KEY,
    type TEXT NOT NULL,
    duration INTERVAL NOT NULL,
    parameters TEXT,
    cost MONEY NOT NULL
);

CREATE TABLE table_operations_of_item(
    ooi_id SERIAL NOT NULL PRIMARY KEY,
    item TEXT NOT NULL REFERENCES table_items(name),
    operation TEXT REFERENCES table_operations(name),
    parent_operation TEXT REFERENCES table_operations(name)
);

CREATE TABLE table_processes(
    process_id SERIAL NOT NULL PRIMARY KEY,
    type TEXT NOT NULL,
    order_id INTEGER REFERENCES table_orders(order_id),
    date_start DATE NOT NULL,
    date_end DATE NOT NULL,
    operation TEXT REFERENCES table_operations(name)
);

CREATE TABLE table_processes_of_equipment(
    poe_id SERIAL NOT NULL PRIMARY KEY,
    equipment_id INTEGER REFERENCES table_equipments(equipment_id),
    process_id INTEGER REFERENCES table_processes(process_id)
    
);

CREATE TABLE table_processes_of_worker(
    pow_id SERIAL NOT NULL PRIMARY KEY,
    worker_id INTEGER REFERENCES table_workers(worker_id),
    process_id INTEGER REFERENCES table_processes(process_id)
);

INSERT INTO table_persons (first_name, last_name, patronymic, date_of_birth)
VALUES ('Василий', 'Васильев', 'Васильевич', '1990-01-01'),
        ('Пётр', 'Петров', 'Петрович', '1995-02-02'),
        ('Сергей', 'Сергеев', 'Сергеевич', '1985-03-03'),
        ('Иван', 'Иванов', 'Иванович', '1998-04-04'),
        ('Максим', 'Максимов', 'Максимович', '1992-05-05'),
        ('Александр', 'Александров', 'Александрович', '1988-06-06'),
        ('Андрей', 'Андреев', 'Андреевич', '1993-07-07'),
        ('Алексей', 'Алексеев', 'Алексеевич', '1999-08-08'),
        ('Артем', 'Артемов', 'Артемович', '1997-09-09'),
        ('Дмитрий', 'Дмитриев', 'Дмитриевич', '1994-10-10');
 
INSERT INTO table_departments (name, leader_id, description)
VALUES ('Отдел снабжения', 1, 'Поставки материалов и оборудования'),
       ('Заготовительный участок', 2, 'Формирование заготовок из материала'),
       ('Токарный участок', 3, 'Токарная обработка заготовок'),
       ('Фрезерный участок', 4, 'Фрезерная обработка заготовок'),
       ('Сварочный участок', 5, 'Сварка деталей'),
       ('Участок сборки', 6, 'Сборка и тестирование готовых изделий'),
       ('Участок покрытий', 7, 'Покрытие изделий'),
       ('Участок упаковки', 8, 'Упаковка готовых изделий'),
       ('Отдел продаж', 9, 'Продажа готовых изделий');


INSERT INTO table_workers (person_id, specialization, date_of_hire, education, date_of_education_end, department, salary)
VALUES (1, 'Снабженец', '2020-01-01', 'Бакалавр', '2020-01-01', 'Отдел снабжения', 50000),
       (2, 'Слесарь', '2020-02-01', 'Среднее специальное', '2020-02-01', 'Заготовительный участок', 35000),
       (3, 'Токарь', '2020-03-01', 'Среднее специальное', '2020-03-01', 'Токарный участок', 37000),
       (4, 'Фрезеровщик', '2020-04-01', 'Среднее специальное', '2020-04-01', 'Фрезерный участок', 36000),
        (5, 'Сварщик', '2020-05-01', 'Среднее специальное', '2020-05-01', 'Сварочный участок', 35000),
        (6, 'Слесарь', '2020-06-01', 'Среднее специальное', '2020-06-01', 'Участок сборки', 32000),
        (7, 'Маляр', '2020-07-01', 'Среднее специальное', '2020-07-02', 'Участок покрытий', 33000),
        (8, 'Слесарь', '2020-08-01', 'Бакалавр', '2020-08-01', 'Участок упаковки', 40000),
        (9, 'Менеджер', '2020-09-01', 'Среднее специальное', '2020-09-01', 'Отдел продаж', 30000),
        (10, 'Сварщик', '2020-10-01', 'Среднее специальное', '2020-10-01', 'Сварочный участок', 35000);

INSERT INTO table_clients (name, address, phone, email, manager_id)
VALUES ('Газпром', 'Москва', '84956789012', 'gazprom@mail.ru', 1),
       ('Роснефть', 'Москва', '84956789013', 'rosneft@mail.ru', 2),
       ('Лукойл', 'Москва', '84956789014', 'lukoil@mail.ru', 3);

INSERT INTO table_orders (name, client, date_start, date_end_plan, total_cost, description)
VALUES ('Заказ 0001', 'Газпром', '2025-01-01', '2025-05-10', 100000, 'Произвести детали трубопровода для газа'),
       ('Заказ 0002', 'Роснефть','2025-01-02', '2025-06-10', 200000, 'Произвести детали трубопровода для нефти'),
       ('Заказ 0003', 'Лукойл','2025-01-03', '2025-07-10', 150000, 'Произвести детали трубопровода для нефти'),
       ('Заказ 0004', 'Газпром','2025-01-04', '2025-08-10', 120000, 'Произвести детали трубопровода для газа'),
       ('Заказ 0005', 'Роснефть','2025-01-05', '2025-09-10', 250000, 'Произвести детали трубопровода для нефти');

INSERT INTO table_equipments (name, type, model, manufacturer, description, price, date_of_purchase, department)
VALUES ('Токарный станок','Токарный','16К20', 'МТЗ', 'Точить детали диаметром до 200 мм', 100000, '2020-01-01', 'Токарный участок'),
        ('Фрезерный станок','Фрезерный', 'Frend', 'МТЗ', 'Фрезировать детали диаметром до 200 мм', 200000, '2020-01-01', 'Фрезерный участок'),
        ('Сварочный аппарат', 'Сварочный','220А', 'Ресанта', 'Сварить детали диаметром до 200 мм', 20000, '2020-01-01', 'Сварочный участок'),
        ('Набор ручного инструмента', 'Слесарный','A-320ZR', 'Force', 'Инструмент для сборки болтовых соединений', 10000, '2020-01-01', 'Участок сборки'),
        ('Покрасочная камера', 'Малярный','B-100', 'Sandmaster', 'Нанесение покрытия на детали', 25000, '2020-01-01', 'Участок покрытий'),
        ('Ленточная пила', 'Пила','RZ-100', 'Powercut', 'Резать заготовки из металла', 15000, '2020-01-01', 'Заготовительный участок'),
        ('Установка лазерной резки', 'Резка', 'BFG-3000', 'Boumfeng','Резка металл толщиной до 20мм', 25000, '2020-01-01', 'Заготовительный участок');


INSERT INTO table_items (name, date_of_produce, parameters, price, is_active)
VALUES ('Труба 219х6', '2025-01-01', 'Хлыст 6м, Ст20', 500, true),
       ('Труба 108х4', '2025-01-02', 'Хлыст 3м, 09Г2С', 300, true),
       ('Лист 3мм', '2025-01-03', 'Лист 1200х2000мм, 09Г2С', 200, true),
       ('Переход К-108х4-219х6', '2025-01-04', 'Ст20', 100, true),
       ('Отвод 108х4', '2025-01-05', 'Ст20', 120, true),
       ('Фланец 100', '2025-01-06', 'Ст20', 500, true),
       ('Фланец 200', '2025-01-07', 'Ст20', 1500, true),
       ('Труба 34х4', '2025-01-08', 'Хлыст 1м, Ст20', 50, true),
       ('Круг 40', '2025-01-09', 'Хлыст 3м, Ст20', 100, true),
       ('Форсунка 01.01',null,'',1000, true),
       ('Штуцер 01.02',null,'',800, true),
       ('Распылитель 01.00',null,'',2500, true),
       ('Корпус 02.01',null,'',5000, true),
       ('Вставка 02.02',null,'',1000, true),
       ('Огнепреградитель 02.00',null,'',10000, true);

INSERT INTO table_subitems (item, parent_item, quantity)
VALUES ('Штуцер 01.02', 'Труба 34х4', 100),
       ('Форсунка 01.01', 'Круг 40', 60),
       ('Распылитель 01.00', 'Форсунка 01.01', 1),
       ('Распылитель 01.00', 'Штуцер 01.02', 1),
       ('Корпус 02.01', 'Фланец 100', 1),
       ('Корпус 02.01', 'Фланец 200', 1),
       ('Вставка 02.02', 'Труба 219х6', 120),
       ('Корпус 02.01', 'Переход К-108х4-219х6', 1),
       ('Огнепреградитель 02.00', 'Корпус 02.01', 2),
       ('Огнепреградитель 02.00', 'Вставка 02.02', 1);

INSERT INTO table_operations (name, type, duration, parameters, cost)
VALUES ('Поставка Труба 219х6', 'Снабжение', '20 day', 'Со склада в Саратове', 1000),
       ('Поставка Труба 108х4', 'Снабжение', '20 day', 'Со склада в Самаре', 500),
       ('Поставка Лист 3мм', 'Снабжение', '15 day', 'Со склада в Екатеринбурге', 400),
       ('Поставка Переход К-108х4-219х6', 'Снабжение', '10 day', 'Со склада в Москве', 100),
       ('Поставка Отвод 108х4', 'Снабжение', '10 day', 'Со склада в Волгограде', 100),
       ('Поставка Фланец 100', 'Снабжение', '10 day', 'Со склада во Владивостоке', 80),
       ('Поставка Фланец 200', 'Снабжение', '10 day', 'Со склада в Пензе', 90),
       ('Поставка Труба 34х4', 'Снабжение', '10 day', 'Со склада в Красноярске', 200),
       ('Поставка Круг 40', 'Снабжение', '10 day', 'Со склада в Краснодаре', 300),
       ('Отрезка DN25', 'Слесарная', '2 min', 'Длина до 100мм', 20),
       ('Отрезка DN40', 'Слесарная', '5 min', 'Длина до 100мм', 25),
       ('Точение DN25', 'Токарная', '15 min', 'Длина до 100мм', 50),
       ('Точение DN40', 'Токарная', '30 min', 'Длина до 100мм', 80),
       ('Фрезерование DN40', 'Фрезерная', '20 min', 'Лыски под ключ', 160),
       ('Сборка распылителя DN25', 'Слесарная', '10 min', 'штуцер и распылитель DN25', 30),
       ('Покраска DN25', 'Малярная', '5 min', 'Длина до 100мм', 50),
       ('Упаковка DN25', 'Слесарная', '10 min', 'Длина до 100мм', 20),
       ('Отрезка трубы DN200', 'Слесарная', '10 min', 'Длина до 100мм', 70),
       ('Точение трубы DN200', 'Слесарная', '5 min', 'Длина до 100мм', 130),
       ('Сварка корпуса DN100', 'Сварочная', '30 min', 'Фланцы DN100, DN200 и переход', 200),
       ('Сборка огнепреградителя DN100', 'Слесарная', '15 min', 'Огнепреградитель DN100', 100),
       ('Покраска DN100', 'Малярная', '25 min', 'Длина до 300мм', 500),
       ('Упаковка DN100', 'Слесарная', '20 min', 'Длина до 300мм', 50);

INSERT INTO table_items_of_order (order_id, item, quantity, cost)
VALUES (1, 'Распылитель 01.00', 10, 25000),
       (1, 'Огнепреградитель 02.00', 5, 50000),
       (2, 'Огнепреградитель 02.00', 10, 100000),
       (3, 'Распылитель 01.00', 50, 125000),
       (4, 'Огнепреградитель 02.00', 20, 200000),
       (5, 'Распылитель 01.00', 100, 250000);

INSERT INTO table_operations_of_item(item, operation, parent_operation)
VALUES ('Распылитель 01.00', 'Упаковка DN25', 'Покраска DN25'),
       ('Распылитель 01.00', 'Покраска DN25', 'Сборка распылителя DN25'),
       ('Распылитель 01.00', 'Сборка распылителя DN25', null),
       ('Форсунка 01.01', 'Фрезерование DN40', 'Точение DN40'),
       ('Форсунка 01.01', 'Точение DN40', 'Отрезка DN40'),
       ('Форсунка 01.01', 'Отрезка DN40', null),
       ('Штуцер 01.02', 'Точение DN25', 'Отрезка DN25'),
       ('Штуцер 01.02', 'Отрезка DN25', null),
       ('Труба 34х4', 'Поставка Труба 34х4', null),
       ('Круг 40', 'Поставка Круг 40', null),
       ('Огнепреградитель 02.00', 'Упаковка DN100', 'Покраска DN100'),
       ('Огнепреградитель 02.00', 'Покраска DN100', 'Сборка огнепреградителя DN100'),
       ('Огнепреградитель 02.00', 'Сборка огнепреградителя DN100', null),
       ('Корпус 02.01', 'Сварка корпуса DN100', null),
       ('Фланец 100', 'Поставка Фланец 100', null),
       ('Фланец 200', 'Поставка Фланец 200', null),
       ('Переход К-108х4-219х6', 'Поставка Переход К-108х4-219х6', null),
       ('Вставка 02.02', 'Точение трубы DN200', 'Отрезка трубы DN200'),
       ('Вставка 02.02', 'Отрезка трубы DN200', null),
       ('Труба 219х6', 'Поставка Труба 219х6', null);