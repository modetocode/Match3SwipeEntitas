using Entitas;
using System;
using UnityEngine;

public class EntityLink : MonoBehaviour {

    public Entity Entity { get { return entity; } }
    public Pool Pool { get { return pool; } }

    private Entity entity;
    private Pool pool;

    public void Link(Entity entity, Pool pool) {
        if (this.entity != null) {
            throw new Exception("EntityLink is already linked to " + this.entity + "!");
        }

        this.entity = entity;
        this.pool = pool;
        this.entity.Retain(this);
    }

    public void Unlink() {
        if (entity == null) {
            throw new Exception("EntityLink is already unlinked!");
        }

        entity.Release(this);
        entity = null;
        pool = null;
    }
}

public static class EntityLinkExtension {

    public static EntityLink GetEntityLink(this GameObject gameObject) {
        return gameObject.GetComponent<EntityLink>();
    }

    public static EntityLink Link(this GameObject gameObject, Entity entity, Pool pool) {
        var link = gameObject.GetEntityLink();
        if (link == null) {
            link = gameObject.AddComponent<EntityLink>();
        }

        link.Link(entity, pool);
        return link;
    }

    public static void Unlink(this GameObject gameObject) {
        gameObject.GetEntityLink().Unlink();
    }
}