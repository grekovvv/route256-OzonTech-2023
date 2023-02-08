create table users
(
    id   bigint primary key,
    name varchar not null
);

insert into users
values (1, 'john'),
       (2, 'Liza'),
       (7, 'Odin'),
       (11, 'donatello'),
       (17, 'spider-man'),
       (19, 'Elen'),
       (20, 'Liza');

create table orders
(
    id         bigint primary key,
    user_id    bigint  not null,
    product    varchar not null,
    constraint fk_orders_user_id foreign key (user_id) references users (id)
);

insert into orders
values (101, 17, 'pizza'),
       (107, 2, 'toothpaste'),
       (108, 19, 'candies'),
       (109, 20, 'pizza'),
       (200, 17, 'shampoo'),
       (205, 2, 'pizza'),
       (210, 19, 'toothpaste'),
       (220, 19, 'pizza'),
       (221, 11, 'shampoo'),
       (222, 19, 'pizza');
