using Zenject;

public class RaceRecorderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IRaceRecorderRepo>().To<RaceRecorderRepo>().AsSingle();
        Container.Bind<IRaceRecorderService>().To<RaceRecorderService>().AsSingle();
    }
}
