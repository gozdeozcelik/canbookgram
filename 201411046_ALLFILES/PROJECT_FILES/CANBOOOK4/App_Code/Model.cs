﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Comment
{
    public int CommentId { get; set; }
    public string CommentText { get; set; }
    public Nullable<int> PostId { get; set; }
    public Nullable<int> PersonId { get; set; }
    public Nullable<bool> IsActive { get; set; }

    public virtual Person Person { get; set; }
    public virtual Post Post { get; set; }
}

public partial class Friend
{
    public int FriendId { get; set; }
    public Nullable<int> Friend1Id { get; set; }
    public Nullable<int> Friend2Id { get; set; }
    public Nullable<bool> isActive { get; set; }

    public virtual Person Person { get; set; }
    public virtual Person Person1 { get; set; }
}

public partial class MessageList
{
    public int MessageId { get; set; }
    public Nullable<int> senderUserId { get; set; }
    public Nullable<int> receiverUserId { get; set; }
    public string MessageText { get; set; }
    public Nullable<System.DateTime> MessageDate { get; set; }
    public Nullable<bool> IsRead { get; set; }
    public Nullable<bool> IsActive { get; set; }

    public virtual Person Person { get; set; }
    public virtual Person Person1 { get; set; }
}

public partial class Person
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Person()
    {
        this.Comment = new HashSet<Comment>();
        this.Friend = new HashSet<Friend>();
        this.Friend1 = new HashSet<Friend>();
        this.MessageList = new HashSet<MessageList>();
        this.MessageList1 = new HashSet<MessageList>();
        this.Post = new HashSet<Post>();
    }

    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string City { get; set; }
    public Nullable<System.DateTime> BirthDate { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Hide { get; set; }
    public string Imagepath { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<int> Post_num { get; set; }
    public Nullable<int> Friend_num { get; set; }
    public Nullable<int> Message_num { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Comment> Comment { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Friend> Friend { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Friend> Friend1 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<MessageList> MessageList { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<MessageList> MessageList1 { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Post> Post { get; set; }
}

public partial class Post
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Post()
    {
        this.Comment = new HashSet<Comment>();
    }

    public int PostId { get; set; }
    public Nullable<int> PostTypeId { get; set; }
    public string PostText { get; set; }
    public string ImagePath { get; set; }
    public Nullable<bool> IsActive { get; set; }
    public Nullable<int> Dislike_num { get; set; }
    public Nullable<int> Like_num { get; set; }
    public Nullable<int> PersonId { get; set; }
    public Nullable<int> Comment_num { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Comment> Comment { get; set; }
    public virtual Person Person { get; set; }
    public virtual PostType PostType { get; set; }
}

public partial class PostType
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public PostType()
    {
        this.Post = new HashSet<Post>();
    }

    public int PostTypeId { get; set; }
    public string PostType1 { get; set; }
    public Nullable<bool> IsActive { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Post> Post { get; set; }
}