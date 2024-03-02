using UnityEngine.Playables;
using UnityTweenPlayables.Core;

namespace UnityTweenPlayables.General {
    /// <summary>
    /// RendererをTweenで動かすためのPlayableClip
    /// </summary>
    public abstract class RendererTweenPlayableClip<TBehaviour> : TweenPlayableClip<TBehaviour>
        where TBehaviour : PlayableBehaviour, ITweenPlayableBehaviour, new() {}
}