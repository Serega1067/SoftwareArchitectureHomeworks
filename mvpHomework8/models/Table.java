package models;

import java.util.ArrayList;
import java.util.Collection;

public class Table {

    private static int counter;
    private int no; // у столика есть номер

    // колекция резервов
    private Collection<Reservation> reservations = new ArrayList<>();

    // создадим инициализатор
    {
        no = ++counter; // каждый раз когда будим создавать новый
        // экземпляр столика столику будит придуман
        // номер
    }

    // создаём возможность получить номер столика

    public int getNo() {
        return no;
    }

    // создаём возможность работать с резервом столика
    public Collection<Reservation> getReservations() {
        return reservations;
    }

    // для красоты, так как будим работоть в рамках консольного
    // приложения переопределим метод toString()
    @Override
    public String toString() {
        return String.format("Столик #%d", no);
    }

    // далее работаем с Reservation.java
}
