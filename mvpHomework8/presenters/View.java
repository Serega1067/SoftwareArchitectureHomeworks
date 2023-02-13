package presenters;

import models.Table;

import java.util.Collection;

public interface View {
    // Booking View имплементирует этот интерфейс

    void showTables(Collection<Table> tables);
    void setObserver(ViewObserver observer);

    void printReservationTableResult(int reservation);

    void printChangeReservationTableResult(int reservation);
}
