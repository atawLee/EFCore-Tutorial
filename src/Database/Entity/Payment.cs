namespace Database.Entity;
using System;
using System.ComponentModel.DataAnnotations;

public abstract class Payment
{
    [Key]
    public int Id { get; set; }

    public decimal Amount { get; set; } // 결제 금액

    public DateTimeOffset PaymentDate { get; set; } = DateTimeOffset.UtcNow; // UTC 0 기준 저장

    [MaxLength(20)]
    public string Status { get; set; } = "Pending"; // "Pending", "Completed", "Failed"
}

public class CreditCardPayment : Payment
{
    [MaxLength(20)]
    public string CardNumber { get; set; } = string.Empty; // 마스킹된 카드번호 (예: ****-****-****-1234)

    [MaxLength(50)]
    public string CardHolder { get; set; } = string.Empty; // 카드 소유자 이름

    [MaxLength(5)]
    public string ExpirationDate { get; set; } = string.Empty; // 유효기간 MM/YY
}

public class PayPalPayment : Payment
{
    [MaxLength(100)]
    public string PayPalEmail { get; set; } = string.Empty; // 페이팔 계정 이메일
}

public class BankTransferPayment : Payment
{
    [MaxLength(30)]
    public string BankAccountNumber { get; set; } = string.Empty; // 가상 계좌번호

    [MaxLength(50)]
    public string BankName { get; set; } = string.Empty; // 은행명
}