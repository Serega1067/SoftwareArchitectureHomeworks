package SoftwareArchitectureHomework1.ModelElements;

public abstract class Model {
    protected location;
    protected angle;

    public Model(location, angle) {
        this.location = location;
        this.angle = angle;
    }

    public abstract void move();
    public abstract void rotate();
}
