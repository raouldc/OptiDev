namespace P02Project.Utils
{
    /// <summary>
    ///     Inferface for objects that can be animated. Any object that is of this type
    ///     can be animated in and out
    /// </summary>
    public interface Animatiable
    {
        void AnimateIn();
        void AnimateOut();
    }
}