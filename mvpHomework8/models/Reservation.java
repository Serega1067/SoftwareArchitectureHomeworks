package models;

import java.util.Date;

public class Reservation {

    private int id; // зарезервированный номер

    // определяем что есть у резерва
    private Date date;
    private String name;

    // далее сгенерируем через гетеры возможность доступа к этим
    // данным, так как они понадобятся
    public int getId() {
        return id;
    }

    public Date getDate() {
        return date;
    }

    public String getName() {
        return name;
    }

    // далее чтобы каждый объект который создыётся имел
    // уникальный номер в рамках песочници
    // добавим counter
    private static int counter;

    // добавим возможность инициализации идентификатора
    // объекта из этого counter в рамках инициализатора
    {
        id = ++counter;
    }

    // далее сделаем так чтобы в отличии от столика для того чтобы
    // создать резерв вы должны вызвать конструктор которому
    // передадите дату и имя того кто бронирует столик
    public Reservation(Date date, String name) {
        // инициализируем дату
        this.date = date;
        this.name = name;
    }
}
