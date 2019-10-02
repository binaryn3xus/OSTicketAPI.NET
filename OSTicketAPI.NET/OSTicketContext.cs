using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET
{
    public class OSTicketContext : DbContext
    {
        public OSTicketContext()
        {
        }

        public OSTicketContext(DbContextOptions<OSTicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OstApiKey> OstApiKey { get; set; }
        public virtual DbSet<OstAttachment> OstAttachment { get; set; }
        public virtual DbSet<OstCannedResponse> OstCannedResponse { get; set; }
        public virtual DbSet<OstConfig> OstConfig { get; set; }
        public virtual DbSet<OstContent> OstContent { get; set; }
        public virtual DbSet<OstDepartment> OstDepartment { get; set; }
        public virtual DbSet<OstDraft> OstDraft { get; set; }
        public virtual DbSet<OstEmail> OstEmail { get; set; }
        public virtual DbSet<OstEmailAccount> OstEmailAccount { get; set; }
        public virtual DbSet<OstEmailTemplate> OstEmailTemplate { get; set; }
        public virtual DbSet<OstEmailTemplateGroup> OstEmailTemplateGroup { get; set; }
        public virtual DbSet<OstEvent> OstEvent { get; set; }
        public virtual DbSet<OstFaq> OstFaq { get; set; }
        public virtual DbSet<OstFaqCategory> OstFaqCategory { get; set; }
        public virtual DbSet<OstFaqTopic> OstFaqTopic { get; set; }
        public virtual DbSet<OstFile> OstFile { get; set; }
        public virtual DbSet<OstFileChunk> OstFileChunk { get; set; }
        public virtual DbSet<OstFilter> OstFilter { get; set; }
        public virtual DbSet<OstFilterAction> OstFilterAction { get; set; }
        public virtual DbSet<OstFilterRule> OstFilterRule { get; set; }
        public virtual DbSet<OstForm> OstForm { get; set; }
        public virtual DbSet<OstFormEntry> OstFormEntry { get; set; }
        public virtual DbSet<OstFormEntryValues> OstFormEntryValues { get; set; }
        public virtual DbSet<OstFormField> OstFormField { get; set; }
        public virtual DbSet<OstGroup> OstGroup { get; set; }
        public virtual DbSet<OstHelpTopic> OstHelpTopic { get; set; }
        public virtual DbSet<OstHelpTopicForm> OstHelpTopicForm { get; set; }
        public virtual DbSet<OstList> OstList { get; set; }
        public virtual DbSet<OstListItems> OstListItems { get; set; }
        public virtual DbSet<OstLock> OstLock { get; set; }
        public virtual DbSet<OstNote> OstNote { get; set; }
        public virtual DbSet<OstOrganization> OstOrganization { get; set; }
        public virtual DbSet<OstPlugin> OstPlugin { get; set; }
        public virtual DbSet<OstQueue> OstQueue { get; set; }
        public virtual DbSet<OstQueueColumn> OstQueueColumn { get; set; }
        public virtual DbSet<OstQueueColumns> OstQueueColumns { get; set; }
        public virtual DbSet<OstQueueConfig> OstQueueConfig { get; set; }
        public virtual DbSet<OstQueueExport> OstQueueExport { get; set; }
        public virtual DbSet<OstQueueSort> OstQueueSort { get; set; }
        public virtual DbSet<OstQueueSorts> OstQueueSorts { get; set; }
        public virtual DbSet<OstRole> OstRole { get; set; }
        public virtual DbSet<OstSearch> OstSearch { get; set; }
        public virtual DbSet<OstSequence> OstSequence { get; set; }
        public virtual DbSet<OstSession> OstSession { get; set; }
        public virtual DbSet<OstSla> OstSla { get; set; }
        public virtual DbSet<OstStaff> OstStaff { get; set; }
        public virtual DbSet<OstStaffDeptAccess> OstStaffDeptAccess { get; set; }
        public virtual DbSet<OstSyslog> OstSyslog { get; set; }
        public virtual DbSet<OstTask> OstTask { get; set; }
        public virtual DbSet<OstTaskCdata> OstTaskCdata { get; set; }
        public virtual DbSet<OstTeam> OstTeam { get; set; }
        public virtual DbSet<OstTeamMember> OstTeamMember { get; set; }
        public virtual DbSet<OstThread> OstThread { get; set; }
        public virtual DbSet<OstThreadCollaborator> OstThreadCollaborator { get; set; }
        public virtual DbSet<OstThreadEntry> OstThreadEntry { get; set; }
        public virtual DbSet<OstThreadEntryEmail> OstThreadEntryEmail { get; set; }
        public virtual DbSet<OstThreadEvent> OstThreadEvent { get; set; }
        public virtual DbSet<OstThreadReferral> OstThreadReferral { get; set; }
        public virtual DbSet<OstTicket> OstTicket { get; set; }
        public virtual DbSet<OstTicketCdata> OstTicketCdata { get; set; }
        public virtual DbSet<OstTicketPriority> OstTicketPriority { get; set; }
        public virtual DbSet<OstTicketStatus> OstTicketStatus { get; set; }
        public virtual DbSet<OstTranslation> OstTranslation { get; set; }
        public virtual DbSet<OstUser> OstUser { get; set; }
        public virtual DbSet<OstUserAccount> OstUserAccount { get; set; }
        public virtual DbSet<OstUserCdata> OstUserCdata { get; set; }
        public virtual DbSet<OstUserEmail> OstUserEmail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OstApiKey>(entity =>
            {
                entity.ToTable("ost_api_key");

                entity.HasIndex(e => e.Apikey)
                    .HasName("apikey")
                    .IsUnique();

                entity.HasIndex(e => e.Ipaddr)
                    .HasName("ipaddr");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apikey)
                    .IsRequired()
                    .HasColumnName("apikey")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CanCreateTickets)
                    .HasColumnName("can_create_tickets")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.CanExecCron)
                    .HasColumnName("can_exec_cron")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ipaddr)
                    .IsRequired()
                    .HasColumnName("ipaddr")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstAttachment>(entity =>
            {
                entity.ToTable("ost_attachment");

                entity.HasIndex(e => new { e.FileId, e.ObjectId })
                    .HasName("file_object")
                    .IsUnique();

                entity.HasIndex(e => new { e.ObjectId, e.FileId, e.Type })
                    .HasName("file-type")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.Inline)
                    .HasColumnName("inline")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<OstCannedResponse>(entity =>
            {
                entity.HasKey(e => e.CannedId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_canned_response");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.Isenabled)
                    .HasName("active");

                entity.HasIndex(e => e.Title)
                    .HasName("title")
                    .IsUnique();

                entity.Property(e => e.CannedId).HasColumnName("canned_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isenabled)
                    .HasColumnName("isenabled")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("'en_US'");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasColumnName("response")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstConfig>(entity =>
            {
                entity.ToTable("ost_config");

                entity.HasIndex(e => new { e.Namespace, e.Key })
                    .HasName("namespace")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Namespace)
                    .IsRequired()
                    .HasColumnName("namespace")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<OstContent>(entity =>
            {
                entity.ToTable("ost_content");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("'other'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstDepartment>(entity =>
            {
                entity.ToTable("ost_department");

                entity.HasIndex(e => e.AutorespEmailId)
                    .HasName("autoresp_email_id");

                entity.HasIndex(e => e.ManagerId)
                    .HasName("manager_id");

                entity.HasIndex(e => e.TplId)
                    .HasName("tpl_id");

                entity.HasIndex(e => new { e.Name, e.Pid })
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AutorespEmailId)
                    .HasColumnName("autoresp_email_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.GroupMembership)
                    .HasColumnName("group_membership")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ispublic)
                    .HasColumnName("ispublic")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ManagerId)
                    .HasColumnName("manager_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MessageAutoResponse)
                    .HasColumnName("message_auto_response")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'/'");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasColumnName("signature")
                    .HasColumnType("text");

                entity.Property(e => e.SlaId)
                    .HasColumnName("sla_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TicketAutoResponse)
                    .HasColumnName("ticket_auto_response")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TplId)
                    .HasColumnName("tpl_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstDraft>(entity =>
            {
                entity.ToTable("ost_draft");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Namespace)
                    .IsRequired()
                    .HasColumnName("namespace")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<OstEmail>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_email");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.PriorityId)
                    .HasName("priority_id");

                entity.Property(e => e.EmailId).HasColumnName("email_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MailActive)
                    .HasColumnName("mail_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MailArchivefolder)
                    .HasColumnName("mail_archivefolder")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MailDelete)
                    .HasColumnName("mail_delete")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MailEncryption)
                    .IsRequired()
                    .HasColumnName("mail_encryption")
                    .HasColumnType("enum('NONE','SSL')");

                entity.Property(e => e.MailErrors)
                    .HasColumnName("mail_errors")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MailFetchfreq)
                    .HasColumnName("mail_fetchfreq")
                    .HasColumnType("tinyint(3)")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.MailFetchmax)
                    .HasColumnName("mail_fetchmax")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.MailHost)
                    .IsRequired()
                    .HasColumnName("mail_host")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MailLasterror)
                    .HasColumnName("mail_lasterror")
                    .HasColumnType("datetime");

                entity.Property(e => e.MailLastfetch)
                    .HasColumnName("mail_lastfetch")
                    .HasColumnType("datetime");

                entity.Property(e => e.MailPort)
                    .HasColumnName("mail_port")
                    .HasColumnType("int(6)");

                entity.Property(e => e.MailProtocol)
                    .IsRequired()
                    .HasColumnName("mail_protocol")
                    .HasColumnType("enum('POP','IMAP')")
                    .HasDefaultValueSql("'POP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Noautoresp)
                    .HasColumnName("noautoresp")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.PriorityId)
                    .HasColumnName("priority_id")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.SmtpActive)
                    .HasColumnName("smtp_active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SmtpAuth)
                    .HasColumnName("smtp_auth")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SmtpHost)
                    .IsRequired()
                    .HasColumnName("smtp_host")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SmtpPort)
                    .HasColumnName("smtp_port")
                    .HasColumnType("int(6)");

                entity.Property(e => e.SmtpSecure)
                    .HasColumnName("smtp_secure")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SmtpSpoofing)
                    .HasColumnName("smtp_spoofing")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Userpass)
                    .IsRequired()
                    .HasColumnName("userpass")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<OstEmailAccount>(entity =>
            {
                entity.ToTable("ost_email_account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Errors).HasColumnName("errors");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasColumnName("host")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Lastconnect)
                    .HasColumnName("lastconnect")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Lasterror)
                    .HasColumnName("lasterror")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Options)
                    .HasColumnName("options")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Protocol)
                    .IsRequired()
                    .HasColumnName("protocol")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(128)");
            });

            modelBuilder.Entity<OstEmailTemplate>(entity =>
            {
                entity.ToTable("ost_email_template");

                entity.HasIndex(e => new { e.TplId, e.CodeName })
                    .HasName("template_lookup")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.CodeName)
                    .IsRequired()
                    .HasColumnName("code_name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TplId).HasColumnName("tpl_id");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstEmailTemplateGroup>(entity =>
            {
                entity.HasKey(e => e.TplId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_email_template_group");

                entity.Property(e => e.TplId)
                    .HasColumnName("tpl_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("'en_US'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<OstEvent>(entity =>
            {
                entity.ToTable("ost_event");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)");
            });

            modelBuilder.Entity<OstFaq>(entity =>
            {
                entity.HasKey(e => e.FaqId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_faq");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("category_id");

                entity.HasIndex(e => e.Ispublished)
                    .HasName("ispublished");

                entity.HasIndex(e => e.Question)
                    .HasName("question")
                    .IsUnique();

                entity.Property(e => e.FaqId).HasColumnName("faq_id");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnName("answer")
                    .HasColumnType("text");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ispublished)
                    .HasColumnName("ispublished")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstFaqCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_faq_category");

                entity.HasIndex(e => e.Ispublic)
                    .HasName("ispublic");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryPid).HasColumnName("category_pid");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Ispublic)
                    .HasColumnName("ispublic")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(125)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstFaqTopic>(entity =>
            {
                entity.HasKey(e => new { e.FaqId, e.TopicId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_faq_topic");

                entity.Property(e => e.FaqId).HasColumnName("faq_id");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");
            });

            modelBuilder.Entity<OstFile>(entity =>
            {
                entity.ToTable("ost_file");

                entity.HasIndex(e => e.Ft)
                    .HasName("ft");

                entity.HasIndex(e => e.Key)
                    .HasName("key");

                entity.HasIndex(e => e.Signature)
                    .HasName("signature");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attrs)
                    .HasColumnName("attrs")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Bk)
                    .IsRequired()
                    .HasColumnName("bk")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'D'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ft)
                    .IsRequired()
                    .HasColumnName("ft")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'T'");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("varchar(86)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasColumnName("signature")
                    .HasColumnType("varchar(86)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<OstFileChunk>(entity =>
            {
                entity.HasKey(e => new { e.FileId, e.ChunkId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_file_chunk");

                entity.Property(e => e.FileId)
                    .HasColumnName("file_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChunkId)
                    .HasColumnName("chunk_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Filedata)
                    .IsRequired()
                    .HasColumnName("filedata");
            });

            modelBuilder.Entity<OstFilter>(entity =>
            {
                entity.ToTable("ost_filter");

                entity.HasIndex(e => e.EmailId)
                    .HasName("email_id");

                entity.HasIndex(e => e.Target)
                    .HasName("target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Execorder)
                    .HasColumnName("execorder")
                    .HasDefaultValueSql("'99'");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MatchAllRules)
                    .HasColumnName("match_all_rules")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StopOnmatch)
                    .HasColumnName("stop_onmatch")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasColumnName("target")
                    .HasColumnType("enum('Any','Web','Email','API')")
                    .HasDefaultValueSql("'Any'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstFilterAction>(entity =>
            {
                entity.ToTable("ost_filter_action");

                entity.HasIndex(e => e.FilterId)
                    .HasName("filter_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Configuration)
                    .HasColumnName("configuration")
                    .HasColumnType("text");

                entity.Property(e => e.FilterId).HasColumnName("filter_id");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstFilterRule>(entity =>
            {
                entity.ToTable("ost_filter_rule");

                entity.HasIndex(e => e.FilterId)
                    .HasName("filter_id");

                entity.HasIndex(e => new { e.FilterId, e.What, e.How, e.Val })
                    .HasName("filter")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.FilterId)
                    .HasColumnName("filter_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.How)
                    .IsRequired()
                    .HasColumnName("how")
                    .HasColumnType("enum('equal','not_equal','contains','dn_contain','starts','ends','match','not_match')");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("tinytext");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Val)
                    .IsRequired()
                    .HasColumnName("val")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.What)
                    .IsRequired()
                    .HasColumnName("what")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<OstForm>(entity =>
            {
                entity.ToTable("ost_form");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Instructions)
                    .HasColumnName("instructions")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(8)")
                    .HasDefaultValueSql("'G'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.HasMany(e => e.OstFormFields)
                    .WithOne(o => o.OstForm);

                entity.HasMany(e => e.OstFormEntries)
                    .WithOne(o => o.OstForm)
                    .HasForeignKey(o => o.FormId);
            });

            modelBuilder.Entity<OstFormEntry>(entity =>
            {
                entity.ToTable("ost_form_entry");

                entity.HasIndex(e => new { e.ObjectType, e.ObjectId })
                    .HasName("entry_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'T'");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.HasMany(e => e.OstFormEntryValues)
                    .WithOne(o => o.OstFormEntry)
                    .HasForeignKey(e => e.EntryId);

                entity.HasOne(o => o.OstForm)
                    .WithMany(o => o.OstFormEntries)
                    .HasForeignKey(e => e.FormId);
            });

            modelBuilder.Entity<OstFormEntryValues>(entity =>
            {
                entity.HasKey(e => new { e.EntryId, e.FieldId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_form_entry_values");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.FieldId).HasColumnName("field_id");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.Property(e => e.ValueId)
                    .HasColumnName("value_id")
                    .HasColumnType("int(11)");

                entity.HasOne(e => e.OstFormField)
                    .WithMany(o => o.OstFormEntryValues)
                    .HasForeignKey(e => e.FieldId);
            });

            modelBuilder.Entity<OstFormField>(entity =>
            {
                entity.ToTable("ost_form_field");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Configuration)
                    .HasColumnName("configuration")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.Hint)
                    .HasColumnName("hint")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Sort).HasColumnName("sort");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'text'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.HasOne(e => e.OstForm)
                    .WithMany(o => o.OstFormFields)
                    .HasForeignKey(e => e.FormId);
            });

            modelBuilder.Entity<OstGroup>(entity =>
            {
                entity.ToTable("ost_group");

                entity.HasIndex(e => e.RoleId)
                    .HasName("role_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(120)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstHelpTopic>(entity =>
            {
                entity.HasKey(e => e.TopicId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_help_topic");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.PageId)
                    .HasName("page_id");

                entity.HasIndex(e => e.PriorityId)
                    .HasName("priority_id");

                entity.HasIndex(e => e.SlaId)
                    .HasName("sla_id");

                entity.HasIndex(e => e.TopicPid)
                    .HasName("topic_pid");

                entity.HasIndex(e => new { e.StaffId, e.TeamId })
                    .HasName("staff_id");

                entity.HasIndex(e => new { e.Topic, e.TopicPid })
                    .HasName("topic")
                    .IsUnique();

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Ispublic)
                    .HasColumnName("ispublic")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Noautoresp)
                    .HasColumnName("noautoresp")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.NumberFormat)
                    .HasColumnName("number_format")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.PageId)
                    .HasColumnName("page_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PriorityId)
                    .HasColumnName("priority_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SequenceId)
                    .HasColumnName("sequence_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SlaId)
                    .HasColumnName("sla_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasColumnName("topic")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TopicPid)
                    .HasColumnName("topic_pid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstHelpTopicForm>(entity =>
            {
                entity.ToTable("ost_help_topic_form");

                entity.HasIndex(e => new { e.TopicId, e.FormId })
                    .HasName("topic-form");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.FormId)
                    .HasColumnName("form_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstList>(entity =>
            {
                entity.ToTable("ost_list");

                entity.HasIndex(e => e.Type)
                    .HasName("type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Configuration)
                    .IsRequired()
                    .HasColumnName("configuration")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Masks)
                    .HasColumnName("masks")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.NamePlural)
                    .HasColumnName("name_plural")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.SortMode)
                    .IsRequired()
                    .HasColumnName("sort_mode")
                    .HasColumnType("enum('Alpha','-Alpha','SortCol')")
                    .HasDefaultValueSql("'Alpha'");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstListItems>(entity =>
            {
                entity.ToTable("ost_list_items");

                entity.HasIndex(e => e.ListId)
                    .HasName("list_item_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ListId)
                    .HasColumnName("list_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Properties)
                    .HasColumnName("properties")
                    .HasColumnType("text");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<OstLock>(entity =>
            {
                entity.HasKey(e => e.LockId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_lock");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.Property(e => e.LockId).HasColumnName("lock_id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Expire)
                    .HasColumnName("expire")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstNote>(entity =>
            {
                entity.ToTable("ost_note");

                entity.HasIndex(e => e.ExtId)
                    .HasName("ext_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ExtId)
                    .HasColumnName("ext_id")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");
            });

            modelBuilder.Entity<OstOrganization>(entity =>
            {
                entity.ToTable("ost_organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasColumnType("varchar(256)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasColumnName("manager")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<OstPlugin>(entity =>
            {
                entity.ToTable("ost_plugin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InstallPath)
                    .IsRequired()
                    .HasColumnName("install_path")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Installed)
                    .HasColumnName("installed")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isphar)
                    .HasColumnName("isphar")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<OstQueue>(entity =>
            {
                entity.ToTable("ost_queue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColumnsId).HasColumnName("columns_id");

                entity.Property(e => e.Config)
                    .HasColumnName("config")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filter)
                    .HasColumnName("filter")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("'/'");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SortId).HasColumnName("sort_id");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstQueueColumn>(entity =>
            {
                entity.ToTable("ost_queue_column");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Annotations)
                    .HasColumnName("annotations")
                    .HasColumnType("text");

                entity.Property(e => e.Conditions)
                    .HasColumnName("conditions")
                    .HasColumnType("text");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Filter)
                    .HasColumnName("filter")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Primary)
                    .IsRequired()
                    .HasColumnName("primary")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Secondary)
                    .HasColumnName("secondary")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Truncate)
                    .HasColumnName("truncate")
                    .HasColumnType("varchar(16)");
            });

            modelBuilder.Entity<OstQueueColumns>(entity =>
            {
                entity.HasKey(e => new { e.QueueId, e.ColumnId, e.StaffId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_queue_columns");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.ColumnId).HasColumnName("column_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Bits)
                    .HasColumnName("bits")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Heading)
                    .HasColumnName("heading")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .HasDefaultValueSql("'100'");
            });

            modelBuilder.Entity<OstQueueConfig>(entity =>
            {
                entity.HasKey(e => new { e.QueueId, e.StaffId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_queue_config");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Setting)
                    .HasColumnName("setting")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstQueueExport>(entity =>
            {
                entity.ToTable("ost_queue_export");

                entity.HasIndex(e => e.QueueId)
                    .HasName("queue_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Heading)
                    .HasColumnName("heading")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<OstQueueSort>(entity =>
            {
                entity.ToTable("ost_queue_sort");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Columns)
                    .HasColumnName("columns")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Root)
                    .HasColumnName("root")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstQueueSorts>(entity =>
            {
                entity.HasKey(e => new { e.QueueId, e.SortId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_queue_sorts");

                entity.Property(e => e.QueueId).HasColumnName("queue_id");

                entity.Property(e => e.SortId).HasColumnName("sort_id");

                entity.Property(e => e.Bits)
                    .HasColumnName("bits")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstRole>(entity =>
            {
                entity.ToTable("ost_role");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Permissions)
                    .HasColumnName("permissions")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstSearch>(entity =>
            {
                entity.HasKey(e => new { e.ObjectType, e.ObjectId })
                    .HasName("PRIMARY");

                entity.ToTable("ost__search");

                entity.HasIndex(e => new { e.Title, e.Content })
                    .HasName("search");

                entity.Property(e => e.ObjectType)
                    .HasColumnName("object_type")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<OstSequence>(entity =>
            {
                entity.ToTable("ost_sequence");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Flags).HasColumnName("flags");

                entity.Property(e => e.Increment)
                    .HasColumnName("increment")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Next)
                    .HasColumnName("next")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Padding)
                    .HasColumnName("padding")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstSession>(entity =>
            {
                entity.HasKey(e => e.SessionId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_session");

                entity.HasIndex(e => e.SessionUpdated)
                    .HasName("updated");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.SessionId)
                    .HasColumnName("session_id")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.SessionData)
                    .HasColumnName("session_data")
                    .HasColumnType("blob");

                entity.Property(e => e.SessionExpire)
                    .HasColumnName("session_expire")
                    .HasColumnType("datetime");

                entity.Property(e => e.SessionUpdated)
                    .HasColumnName("session_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasColumnName("user_agent")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserIp)
                    .IsRequired()
                    .HasColumnName("user_ip")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<OstSla>(entity =>
            {
                entity.ToTable("ost_sla");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.GracePeriod)
                    .HasColumnName("grace_period")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_staff");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.Isadmin)
                    .HasName("issuperuser");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.AssignedOnly)
                    .HasColumnName("assigned_only")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.AutoRefreshRate)
                    .HasColumnName("auto_refresh_rate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Backend)
                    .HasColumnName("backend")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.ChangePasswd)
                    .HasColumnName("change_passwd")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefaultPaperSize)
                    .IsRequired()
                    .HasColumnName("default_paper_size")
                    .HasColumnType("enum('Letter','Legal','Ledger','A4','A3')")
                    .HasDefaultValueSql("'Letter'");

                entity.Property(e => e.DefaultSignatureType)
                    .IsRequired()
                    .HasColumnName("default_signature_type")
                    .HasColumnType("enum('none','mine','dept')")
                    .HasDefaultValueSql("'none'");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Isadmin)
                    .HasColumnName("isadmin")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isvisible)
                    .HasColumnName("isvisible")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Lastlogin)
                    .HasColumnName("lastlogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.MaxPageSize)
                    .HasColumnName("max_page_size")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(24)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Onvacation)
                    .HasColumnName("onvacation")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Passwd)
                    .HasColumnName("passwd")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Passwdreset)
                    .HasColumnName("passwdreset")
                    .HasColumnType("datetime");

                entity.Property(e => e.Permissions)
                    .HasColumnName("permissions")
                    .HasColumnType("text");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(24)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PhoneExt)
                    .HasColumnName("phone_ext")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShowAssignedTickets)
                    .HasColumnName("show_assigned_tickets")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasColumnName("signature")
                    .HasColumnType("text");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<OstStaffDeptAccess>(entity =>
            {
                entity.HasKey(e => new { e.StaffId, e.DeptId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_staff_dept_access");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstSyslog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_syslog");

                entity.HasIndex(e => e.LogType)
                    .HasName("log_type");

                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Log)
                    .IsRequired()
                    .HasColumnName("log")
                    .HasColumnType("text");

                entity.Property(e => e.LogType)
                    .IsRequired()
                    .HasColumnName("log_type")
                    .HasColumnType("enum('Debug','Warning','Error')");

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasColumnName("logger")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstTask>(entity =>
            {
                entity.ToTable("ost_task");

                entity.HasIndex(e => e.Created)
                    .HasName("created");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.HasIndex(e => e.TeamId)
                    .HasName("team_id");

                entity.HasIndex(e => new { e.ObjectId, e.ObjectType })
                    .HasName("object");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Closed)
                    .HasColumnName("closed")
                    .HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LockId)
                    .HasColumnName("lock_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasColumnType("char(1)");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstTaskCdata>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_task__cdata");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<OstTeam>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_team");

                entity.HasIndex(e => e.LeadId)
                    .HasName("lead_id");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.LeadId)
                    .HasColumnName("lead_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(125)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstTeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.StaffId })
                    .HasName("PRIMARY");

                entity.ToTable("ost_team_member");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstThread>(entity =>
            {
                entity.ToTable("ost_thread");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("object_id");

                entity.HasIndex(e => e.ObjectType)
                    .HasName("object_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Lastmessage)
                    .HasColumnName("lastmessage")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lastresponse)
                    .HasColumnName("lastresponse")
                    .HasColumnType("datetime");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<OstThreadCollaborator>(entity =>
            {
                entity.ToTable("ost_thread_collaborator");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.HasIndex(e => new { e.ThreadId, e.UserId })
                    .HasName("collab")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'M'");

                entity.Property(e => e.ThreadId)
                    .HasColumnName("thread_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstThreadEntry>(entity =>
            {
                entity.ToTable("ost_thread_entry");

                entity.HasIndex(e => e.Pid)
                    .HasName("pid");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.HasIndex(e => e.ThreadId)
                    .HasName("thread_id");

                entity.HasIndex(e => e.Type)
                    .HasName("type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("text");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Editor).HasColumnName("editor");

                entity.Property(e => e.EditorType)
                    .HasColumnName("editor_type")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnName("format")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("'html'");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Poster)
                    .IsRequired()
                    .HasColumnName("poster")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Recipients)
                    .HasColumnName("recipients")
                    .HasColumnType("text");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ThreadId)
                    .HasColumnName("thread_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstThreadEntryEmail>(entity =>
            {
                entity.ToTable("ost_thread_entry_email");

                entity.HasIndex(e => e.Mid)
                    .HasName("mid");

                entity.HasIndex(e => e.ThreadEntryId)
                    .HasName("thread_entry_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Headers)
                    .HasColumnName("headers")
                    .HasColumnType("text");

                entity.Property(e => e.Mid)
                    .IsRequired()
                    .HasColumnName("mid")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ThreadEntryId).HasColumnName("thread_entry_id");
            });

            modelBuilder.Entity<OstThreadEvent>(entity =>
            {
                entity.ToTable("ost_thread_event");

                entity.HasIndex(e => new { e.Timestamp, e.EventId })
                    .HasName("ticket_stats");

                entity.HasIndex(e => new { e.ThreadId, e.EventId, e.Timestamp })
                    .HasName("ticket_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Annulled)
                    .HasColumnName("annulled")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.ThreadId)
                    .HasColumnName("thread_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.UidType)
                    .IsRequired()
                    .HasColumnName("uid_type")
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("'S'");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'SYSTEM'");
            });

            modelBuilder.Entity<OstThreadReferral>(entity =>
            {
                entity.ToTable("ost_thread_referral");

                entity.HasIndex(e => e.ThreadId)
                    .HasName("thread_id");

                entity.HasIndex(e => new { e.ObjectId, e.ObjectType, e.ThreadId })
                    .HasName("ref")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectType)
                    .IsRequired()
                    .HasColumnName("object_type")
                    .HasColumnType("char(1)");

                entity.Property(e => e.ThreadId).HasColumnName("thread_id");
            });

            modelBuilder.Entity<OstTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_ticket");

                entity.HasIndex(e => e.Closed)
                    .HasName("closed");

                entity.HasIndex(e => e.Created)
                    .HasName("created");

                entity.HasIndex(e => e.DeptId)
                    .HasName("dept_id");

                entity.HasIndex(e => e.Duedate)
                    .HasName("duedate");

                entity.HasIndex(e => e.SlaId)
                    .HasName("sla_id");

                entity.HasIndex(e => e.StaffId)
                    .HasName("staff_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.HasIndex(e => e.TeamId)
                    .HasName("team_id");

                entity.HasIndex(e => e.TopicId)
                    .HasName("topic_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.Closed)
                    .HasColumnName("closed")
                    .HasColumnType("datetime");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstDuedate)
                    .HasColumnName("est_duedate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("ip_address")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Isanswered)
                    .HasColumnName("isanswered")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Isoverdue)
                    .HasColumnName("isoverdue")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lastupdate)
                    .HasColumnName("lastupdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LockId)
                    .HasColumnName("lock_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Reopened)
                    .HasColumnName("reopened")
                    .HasColumnType("datetime");

                entity.Property(e => e.SlaId)
                    .HasColumnName("sla_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasColumnType("enum('Web','Email','Phone','API','Other')")
                    .HasDefaultValueSql("'Other'");

                entity.Property(e => e.SourceExtra)
                    .HasColumnName("source_extra")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.StaffId)
                    .HasColumnName("staff_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TeamId)
                    .HasColumnName("team_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserEmailId)
                    .HasColumnName("user_email_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(e => e.OstFormEntry)
                    .WithOne(o => o.OstTicket)
                    .IsRequired(false)
                    .HasForeignKey<OstFormEntry>(f => f.ObjectId);
            });

            modelBuilder.Entity<OstTicketCdata>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_ticket__cdata");

                entity.Property(e => e.TicketId)
                    .HasColumnName("ticket_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<OstTicketPriority>(entity =>
            {
                entity.HasKey(e => e.PriorityId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_ticket_priority");

                entity.HasIndex(e => e.Ispublic)
                    .HasName("ispublic");

                entity.HasIndex(e => e.Priority)
                    .HasName("priority")
                    .IsUnique();

                entity.HasIndex(e => e.PriorityUrgency)
                    .HasName("priority_urgency");

                entity.Property(e => e.PriorityId)
                    .HasColumnName("priority_id")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Ispublic)
                    .HasColumnName("ispublic")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Priority)
                    .IsRequired()
                    .HasColumnName("priority")
                    .HasColumnType("varchar(60)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PriorityColor)
                    .IsRequired()
                    .HasColumnName("priority_color")
                    .HasColumnType("varchar(7)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PriorityDesc)
                    .IsRequired()
                    .HasColumnName("priority_desc")
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PriorityUrgency)
                    .HasColumnName("priority_urgency")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<OstTicketStatus>(entity =>
            {
                entity.ToTable("ost_ticket_status");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.State)
                    .HasName("state");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mode)
                    .HasColumnName("mode")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(60)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Properties)
                    .IsRequired()
                    .HasColumnName("properties")
                    .HasColumnType("text");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstTranslation>(entity =>
            {
                entity.ToTable("ost_translation");

                entity.HasIndex(e => e.ObjectHash)
                    .HasName("object_hash");

                entity.HasIndex(e => new { e.Type, e.Lang })
                    .HasName("type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AgentId)
                    .HasColumnName("agent_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ObjectHash)
                    .HasColumnName("object_hash")
                    .HasColumnType("char(16)");

                entity.Property(e => e.Revision).HasColumnName("revision");

                entity.Property(e => e.SourceText)
                    .HasColumnName("source_text")
                    .HasColumnType("text");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("enum('phrase','article','override')");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp");
            });

            modelBuilder.Entity<OstUser>(entity =>
            {
                entity.ToTable("ost_user");

                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.OrgId)
                    .HasName("org_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.DefaultEmailId)
                    .HasColumnName("default_email_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.OrgId).HasColumnName("org_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<OstUserAccount>(entity =>
            {
                entity.ToTable("ost_user_account");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id");

                entity.HasIndex(e => e.Username)
                    .HasName("username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Backend)
                    .HasColumnName("backend")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("text");

                entity.Property(e => e.Lang)
                    .HasColumnName("lang")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Passwd)
                    .HasColumnName("passwd")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Registered)
                    .HasColumnName("registered")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<OstUserCdata>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("ost_user__cdata");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("mediumtext");
            });

            modelBuilder.Entity<OstUserEmail>(entity =>
            {
                entity.ToTable("ost_user_email");

                entity.HasIndex(e => e.Address)
                    .HasName("address")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("user_email_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Flags)
                    .HasColumnName("flags")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });
        }
    }
}
