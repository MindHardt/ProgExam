Заблудившийся робот. Дан файл. На первой строке записана координата начальной точки, в которой находится робот. На второй строке координата, в которую должен прийти робот. Далее на следующих строках даны команды роботу, куда ему двигаться. Движение может быть, вверх, вниз, влево, вправо, и по диагоналям вверх-влево, вверх-вправо, вниз-влево и вниз-вправо.

Отсчет координат идет от верхнего левого угла, там находится точка [0;0]. Первое число - координата по горизонтали (х), второе - по вертикали (у). Список команд:
```
l - left
r - right
u - up
d - down
dul - diagonal up left
dur - diagonal up right
ddl - diagonal down left
ddr - diagonal down right
```

Вывести на экран, доберется ли робот до заданной точки, следуя инструкциям. Для пятерки, нужно реализовать визуализацию с пошаговым отображением, как двигается робот. Вам понадобятся консольные команды управления курсором - Console.SetCursorPosition(int, int).

Пример файла:
```
2;3
1;0
dul 1
u 2
```

Должно вывестись true. Робот сначала поднимается на 1 клетку по диагонали вверх влево, затем на 2 клетки вверх. Координата будет равна 1;0 - верно.
