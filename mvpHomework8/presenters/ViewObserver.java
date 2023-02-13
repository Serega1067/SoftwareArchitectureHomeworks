package presenters;

import java.util.Date;

// Это некий наблюдатель
public interface ViewObserver {
    void onReservationTable(Date orderDate,
                            int tableNo,
                            String name);


    // Задание
    void onChangeReservationTable(int oldReservation,
                                  Date orderDate,
                                  int tableNo,
                                  String name);
}
