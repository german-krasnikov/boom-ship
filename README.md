## Реализация:
Не использовались сторонние библиотеки, для максимального упрощения
## Архитектура:
- Используется одна StateMachine, для управления состояниями(подключение зависимостей, настройка, игра, результат игры)
- Плоская архитектура, что-то вроде гибрида MVP+ECS. Предпочитал композицию наследованию.
- Для обработки бизнесслогики используется один Update
- Добавил поведение пуль, при выстреле создается пуля летящаяя в сторону противника, нанесение урона отложено до попадения. Для них используюется Pool
- Для управления зависимостями используется ServiceLocator


## ТЗ
У нас есть космический корабль. Он состоит из различных модулей улучшающих характеристики корабля. Корабль имеет базовые ХП и щит, щит восстанавливается со временем.
Необходимо сделать простой прототип, где на экране будет два корабля, можно выбрать модули для обоих кораблей и начать бой. Критерий победы – смерть одного из кораблей.
- Данные:
- Корабль А:
Жизнь 100
Щит 80, скорость восстановления 1 единица в секунду
2 слота для оружия
2 слота для модулей
- Корабль Б:
Жизнь 60
Щит 120, скорость восстановления 1 единица в секунду
2 слота для оружия
3 слота для модулей
- Модули:
- Пушка А – 3 секунды выстрел, 5 дамага
- Пушка Б – 2 секунды, 4 дамага
- Пушка С – 5 секунды, 20 дамага
- Модуль А - +50 щита
- Модуль Б - +50 жизни
- Модуль С - -20% перезарядки
- Модуль Д - +20% восстановление щита
