-- Типы техники: Большой грузовик, Средний трактор, Маленький тягач, etc
create table vehicle_types
(
	id serial primary key,
	name varchar not null
);

-- Единицы техники: Грузовик Вольво
create table vehicles
(
	id serial primary key,
	type_id int not null references vehicle_types(id),
	name varchar not null,
	state_number varchar
);

-- Типы навесного оборудования: ковши, щетки, цистерны
create table equipment_types
(
	id serial not null primary key,
	name varchar not null
);

-- Единицы навесного оборудования
create table equipment_units
(
	id serial not null primary key,
	type_id int not null references equipment_types(id),
	name varchar not null
);

-- Совместимость навесного оборудования с типами техники
-- Задел на будущее: совместимость надо более детально специфицировать
-- Задел на будущее: учесть стоимость монтажа и демонтажа оборудования
create table equipment_compatibility
(
	vehicle_type_id int not null references vehicle_types(id),
	equipment_type_id int not null references equipment_types(id)
);

-- Комплектация техники (какой кош навешан на какой грузовик)
create table vehicle_equipment
(
	vehicle_id int not null references vehicles(id),
	equipment_id int not null references equipment_units(id)
);

-- Предприятия
create table companies
(
	id serial not null primary key,
	name varchar not null
);

-- Единицы техники у предприятий
create table company_vehicles
(
	company_id int not null references companies(id),
	vehicle_id int not null references vehicles(id)
);

-- Единицы оборудования у предприятий
create table company_equipment
(
	company_id int not null references companies(id),
	equipment_id int not null references equipment_units(id)
);

-- Шаблоны задач: например, уборка террирории
create table template_tasks
(
	id serial not null primary key,
	name varchar not null	
);

-- Шаблоны технологических операций: сгребание снега, вывоз снега, чистка конюшен
-- Задел на будущее: учесть стоимость операций
create table template_operations
(
	id serial not null primary key,
	name varchar not null,
	vehicle_type_id int references vehicle_types(id), -- необязательно (=любой годный транспорт)
	equipment_type_id int references equipment_types(id), -- необязательно (например, нужен только грузовик)
	speed numeric not null -- скорость (время уборки единицы площади)
);

-- Шаблонные операции в задачах
create table template_task_operations
(
	template_task_id int not null references template_tasks(id),
	template_operation_id int not null references template_operations(id),
	order_number int not null default 1
);

-- Задачи: уборка территории завода ЗИЛ
create table tasks
(
	id serial not null primary key,
	template_task_id int not null references template_tasks(id),
	name varchar not null, 
	date timestamptz(0) not null default current_timestamp,
	quantity numeric not null
);

-- Операции: чистка главной площади территории завода ЗИЛ, например
create table operations
(
	id serial not null primary key,
	task_id int not null references tasks(id),
	order_number int not null default 1,
	template_operation_id int not null references template_operations(id),
	name varchar not null
);
